using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGUI.Forms;

namespace TestGUI.Forms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Receiver.Map("signin_success", (response) =>
            {
                BeginInvoke(new Action(() =>
                {
                    Hide();
                    (new ChatForm(response?.Username?.ToString())).ShowDialog();
                    Close();
                }));
            });


            Program.Receiver.Map("signin_error", (response) =>
            {
                MessageBox.Show(this, "Incorrect credentials.", "Error", MessageBoxButtons.OK);
            });



            Program.Receiver.Network.Send(new
            {
                Type = "signin",
                Username = textBox1.Text,
                Password = textBox2.Text,
                LogInTime = DateTime.Now.ToString()
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.ReceiverThread.Abort();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SignUpForm()).ShowDialog();
            this.Close();
        }
    }
}
