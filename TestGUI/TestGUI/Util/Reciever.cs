using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGUI.Util
{
    public class Receiver
    {
        public NetworkHandler Network { get; set; }
        private IDictionary<string, Action<dynamic>> dict;

        public Receiver(string ip, int port)
        {
            Network = new NetworkHandler(ip, port);
            dict = new Dictionary<string, Action<dynamic>>();
        }

        public void Start()
        {
            while (true)
            {
                var response = Network.Receive();
                string type = response?.Type?.ToString();
                if (type == null) continue;
                try
                {
                    var callback = dict[type];
                    callback(response);
                }
                catch (KeyNotFoundException ex)
                {
                    throw ex;
                }
            }
        }

        public void Map(string type, Action<dynamic> callback)
        {
            dict[type] = callback;
        }
    }
}
