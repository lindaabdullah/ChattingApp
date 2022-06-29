using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGUI.UserControls
{
	public partial class ChatBox : UserControl
	{
		public ChatBox(string username, string sentAt, string message)
		{
			InitializeComponent();
			label1.Text = username;
			label2.Text = sentAt;
			richTextBox1.Text = message;
			Dock = DockStyle.Bottom;
			BringToFront();
		}
	}
}
