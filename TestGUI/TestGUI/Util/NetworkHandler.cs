using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace TestGUI
{
    public class NetworkHandler
    {
        private static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        private IPHostEntry host;
        private IPAddress ipAddress;
        private int port;
        private IPEndPoint localEndPoint;
        private Socket sender;

        public NetworkHandler(string address, int port)
        {   
            host = Dns.GetHostEntry(address);
            ipAddress = host.AddressList[0];
            this.port = port;

            localEndPoint = new IPEndPoint(ipAddress, port);
            sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);
        }

        // ------------------------------------------
        // Sending
        // ------------------------------------------
        public static byte[] StringToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public void SendString(string str)
        {
            sender.Send(StringToByteArray(str));
        }

        public static string Serialize(dynamic data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public void Send(dynamic data)
        {
            SendString(Serialize(data));
        }
        // ------------------------------------------


        // ------------------------------------------
        // Receiving
        // ------------------------------------------
        public static string ByteArrayToString(byte[] arr)
        {
            return Encoding.UTF8.GetString(arr);
        }

        public string ReceiveString()
        {
            while (sender.Available == 0)
            {
            }
            byte[] buffer = new byte[1024];
            int count = sender.Receive(buffer);

            return ByteArrayToString(buffer.Take(count).ToArray());
        }

        public static dynamic Deserialize(string str)
        {
             return JsonConvert.DeserializeObject(str);
        }

        public dynamic Receive()
        {
            return Deserialize(ReceiveString());
        }
        // ------------------------------------------

        public void Close()
        {
            sender.Close();
        }

        public static string Encrypt(string originalString)
        {
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

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
