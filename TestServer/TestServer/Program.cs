﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using TestServer.Util;
using System.Data.Entity.Validation;
using TestServer.Model;

namespace TestServer
{
	using NetworkHandlerSocket = NetworkHandler.NetworkHandlerSocket;
    public class Program
	{
		public static Model1 db = new Model1();
		public static NetworkHandler network;
		public static NetworkHandlerSocket ns;
		public static localhost.WebService1 ws = new localhost.WebService1();
		public static IDictionary<NetworkHandlerSocket, Employee> activeUsers = new Dictionary<NetworkHandlerSocket, Employee>();
		
		public static dynamic SignIn(NetworkHandlerSocket handler, dynamic data)
        {
			string username = data.Username.ToString();
			string password = data.Password.ToString();
			var emp = db.Employees.FirstOrDefault(i => i.Username == username && i.Password == password);

			if (emp != null)
			{
				activeUsers[handler] = emp;
				foreach (var socket in activeUsers.Keys)
                {
					if (socket != handler)
						socket.Send(Active());
                }
                Console.WriteLine($"Active users count: {activeUsers.Count}");

				ws.AddToLogIn(username);
				
				return new { Type = "signin_success", Username = username };
			}
			else
				return new { Type = "signin_error" };
		}

		public static dynamic SignUp(dynamic data)
		{
			ws.AddEmployee(int.Parse(data.SSN.ToString()), data.Name.ToString(), data.Surname.ToString(), data.Username.ToString(), data.Password.ToString(), data.Email.ToString(), data.Address.ToString());

			return new { Type = "signup_success" };
		}

		public static dynamic Active()
        {
			return new { Type = "active", Users = activeUsers.Values.Select(emp => new
            {
				Username = emp.Username,
				Status = "Online"
            }).ToArray() };
		}


		public static void PrivateOldMessage(dynamic data)
        {
			string From = data.From.ToString();
			string To = data.To.ToString();
			string RequestingUser = data.requestingUser.ToString();

			var oldmessages = db.Chattings.Where(i => ((i.SenderUsername == From && i.RecieverUsername == To) || (i.SenderUsername == To && i.RecieverUsername == From)) && i.ChattingType == "Private").Select(i => new { i.SenderUsername, i.Message, i.DateSent, i.Encrypted }).ToArray();

			if (oldmessages != null)
			{
				Console.WriteLine(NetworkHandler.Serialize(oldmessages));

				var requestingSocket = activeUsers.FirstOrDefault(x => x.Value.Username == RequestingUser).Key;

				requestingSocket.Send(new
				{
					Type = "private old messages",
					Messages = oldmessages
				});
			}
		}

		public static void BroadCast(dynamic data)
		{
			string from = data.From.ToString();
			string BroadastMsg = data.BroadCastMessage.ToString();
			string datesent = data.DateSentAt.ToString();
			string encrypted = data.Encrypt.ToString();


			foreach (var activeSockets in activeUsers)
			{
				string reqUser = activeSockets.Value.Username.ToString();

				ws.AddToChatting(from, reqUser, datesent, BroadastMsg, "Broadcast", encrypted);
				 
				
				activeSockets.Key.Send(new // send broadcasted message to active sockets
				{ 
					Type = "BroadCast", 
					BroadcastMessage = BroadastMsg, 
					date = datesent.ToString(), 
					FromUser = from,
					Encrypt = encrypted
				});

			}
		}

		public static void Message(dynamic data)
		{
			var to = activeUsers.FirstOrDefault(i => i.Value.Username == data.To.ToString());
			var response = new
			{
				Type = "private_message",
				Username = data.From,
				SentAt = data.SentAt,
				Message = data.Message,
				ChattingType = "Private",
				Encrypt = data.Encrypt
			};

			to.Key.Send(response);
			var datenow = DateTime.Now.ToString();

			ws.AddToChatting(data.From.ToString(), data.To.ToString(), datenow, data.Message.ToString(), "Private", data.Encrypt.ToString());
		}

		public static void SocketLoop(NetworkHandlerSocket handler)
        {
            try
            {
				dynamic data = handler.Receive();
				dynamic response = null;

				try
				{
					Console.WriteLine($"Received {NetworkHandler.Serialize(data)}");

					if (data.Type == "signin")
                    {
						response = SignIn(handler, data);
						Console.WriteLine($"Sending {NetworkHandler.Serialize(response)}");
						handler.Send(response);
					}
					else if (data.Type == "signup")
                    {
						response = SignUp(data);
						Console.WriteLine($"Sending {NetworkHandler.Serialize(response)}");
						handler.Send(response);
					}
					else if (data.Type == "active")
                    {
						response = Active();
						Console.WriteLine($"Sending {NetworkHandler.Serialize(response)}");
						handler.Send(response);
					}
					
					else if (data.Type == "private_message")
						Message(data);

					else if (data.Type == "private old messages")
						PrivateOldMessage(data);

					else if (data.Type == "BroadCast")
						BroadCast(data);
					
				}
				catch (Exception ex)
				{
					response = new { Type = "error", Message = ex.Message };
					Console.WriteLine(ex);
				}
			}
			catch (SocketException)
			{
				return;
			}
		}

        static void Main(string[] args)
        {
			network = new NetworkHandler("localhost", 777);
			while (true)
            {
				var handler = network.Accept(); // will wait until client connects to server

				new Thread(() =>
					{

						Console.WriteLine("Client connected");
						while (handler.Connected) SocketLoop(handler);
						Console.WriteLine("Client disconnected");
						
						ws.AddToLogoutLogs(activeUsers[handler].Username);
						
						activeUsers.Remove(handler);
						
						Console.WriteLine($"Active users count: {activeUsers.Count}");
						foreach (var socket in activeUsers.Keys)
						{
							socket.Send(Active());
						}
					}
				).Start();
            }
		}
    }
}
