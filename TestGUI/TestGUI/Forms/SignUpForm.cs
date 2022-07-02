using System;
using System.Windows.Forms;

namespace TestGUI.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Receiver.Map("signup_success", (response) =>
            {
                BeginInvoke(new Action(() =>
                {
                    Hide();
                    (new SignInForm()).ShowDialog();
                    Close();
                }));
            });

            Program.Receiver.Map("signup_error", (response) =>
            {
                MessageBox.Show(this, "Missing Fields or employee already exists.", "Error", MessageBoxButtons.OK);
            });

            Program.Receiver.Network.Send(new
            {
                Type = "signup",
                SSN = NewSSN.Text,
                Name = NewName.Text,
                Surname = NewSurname.Text,
                Username = NewUsername.Text,
                Password = NewPassword.Text,
                Email = NewEmail.Text,
                Address = NewAddress.Text
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            (new SignInForm()).ShowDialog();
            Close();
        }
    }
}
