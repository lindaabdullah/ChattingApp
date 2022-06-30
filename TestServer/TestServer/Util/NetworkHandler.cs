using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace TestServer.Util
{
    public class NetworkHandler
    {
        private byte[] bytes;
        private IPHostEntry host;
        private IPAddress ipAddress;
        private int port;
        private IPEndPoint localEndPoint;
        private Socket listener;

        public NetworkHandler(string address, int port)
        {
            host = Dns.GetHostEntry(address);
            ipAddress = host.AddressList[0];
            this.port = port;

            localEndPoint = new IPEndPoint(ipAddress, port);
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Console.WriteLine($"Listening at {ipAddress}:{port}");
        }

        public NetworkHandlerSocket Accept()
        {
            return new NetworkHandlerSocket(listener.Accept());
        }

        public class NetworkHandlerSocket
        {
            private Socket handler;
            public bool Connected { get; set; }

            public NetworkHandlerSocket(Socket handler)
            {
                this.handler = handler;
                Connected = true;
                new Thread(() =>
                {
                    while (IsConnected())
                        Thread.Sleep(1000);
                }).Start();
            }

            public bool IsConnected()
            {
                Connected = !(handler.Poll(1000, SelectMode.SelectRead) && handler.Available == 0);
                return Connected;
            }

            public void SendString(string str)
            {
                handler.Send(StringToByteArray(str));
            }

            public void Send(dynamic data)
            {
                SendString(Serialize(data));
            }

            public string ReceiveString()
            {
                while (handler.Available == 0)
                {
                    if (!Connected)
                        throw new SocketException();
                }
                byte[] buffer = new byte[10240];
                int count = handler.Receive(buffer);

                return ByteArrayToString(buffer.Take(count).ToArray());
            }

            public dynamic Receive()
            {
                return Deserialize(ReceiveString());
            }
        }

        // ------------------------------------------
        // Sending
        // ------------------------------------------
        public static byte[] StringToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string Serialize(dynamic data)
        {
            return JsonConvert.SerializeObject(data);
        }
        // ------------------------------------------

        // ------------------------------------------
        // Receiving
        // ------------------------------------------
        public static string ByteArrayToString(byte[] arr)
        {
            return Encoding.UTF8.GetString(arr);
        }

        public static dynamic Deserialize(string str)
        {
            return JsonConvert.DeserializeObject(str);
        }
        // ------------------------------------------

        public string Encrypt(string originalString)
        {
            bytes = ASCIIEncoding.ASCII.GetBytes(originalString);
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
    }
}
