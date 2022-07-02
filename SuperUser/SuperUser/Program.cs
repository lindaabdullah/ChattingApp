using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuperUser.localhost1.WebService1 ws = new localhost1.WebService1();
            while (true)
            {
                Console.WriteLine("Do you wish to view a table? (yes/no)");
                var Show = Console.ReadLine();

                switch (Show)
                {
                    case "yes":
                    Console.WriteLine("Enter the table you want to see: \n 1- Employee \n 2- LoginLog \n 3- LogoutLog \n 4- Chatting");
                    var command = Console.ReadLine(); 
                    
                        switch (command)
                        {
                            case "Employee":
                                var ListOfEmployees = ws.AllEmployees();
                                foreach (var emp in ListOfEmployees)
                                {
                                    Console.WriteLine($"Employee: SSN: {emp.SSN}, name: {emp.Name}, surname: {emp.Surname}, username: {emp.Username}, surname: {emp.Password}, email: {emp.Email}, address: {emp.Address} \n");
                                }
                                break;

                            case "LoginLog":
                                var ListOfLogin = ws.AllLoginLogs();
                                foreach (var log in ListOfLogin)
                                {
                                    Console.WriteLine($"Login: Username: {log.Username}, Time: {log.Time}\n");
                                }
                                break;

                            case "LogoutLog":
                                var ListOfLogout = ws.AllLogoutLogs();
                                foreach (var log in ListOfLogout)
                                {
                                    Console.WriteLine($"Logout: Username: {log.Username}, Time: {log.Time}\n");
                                }
                                break;

                            case "Chatting":
                                var ListOfChatting = ws.AllChatting();
                                foreach (var log in ListOfChatting)
                                {
                                    Console.WriteLine($"Chat: SenderUsername: {log.SenderUsername}, RecieverUsername: {log.RecieverUsername}, DateSent: {log.DateSent}, Message: {log.Message}, ChattingType: {log.ChattingType}, Encrypted: {log.Encrypted}\n");
                                }
                                break;
                            case "exit":
                                return;

                        }
                    break;

                    case "no":
                        return;
                }

            }
        }
    }
}
