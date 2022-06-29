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
	public partial class UserBox : UserControl
	{
		public string Username { get; set; }
		public string Status { get; set; }

		public UserBox(string username, string status)
		{
			InitializeComponent();
			Username = username;
			Status = status;
			label1.Text = username;
			label2.Text = status;
			Dock = DockStyle.Top;
			BringToFront();
		}
	}
}
