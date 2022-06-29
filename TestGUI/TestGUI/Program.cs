using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TestGUI.Util;
using TestGUI.Forms;

namespace TestGUI
{
    internal static class Program
    {
        public static Receiver Receiver { get; set; }
        public static Thread ReceiverThread { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Receiver = new Receiver("localhost", 777);
            ReceiverThread = new Thread(() => Receiver.Start());
            ReceiverThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInForm());
            Receiver.Network.Close();
            ReceiverThread.Abort();
            Application.Exit();
        }
    }
}
