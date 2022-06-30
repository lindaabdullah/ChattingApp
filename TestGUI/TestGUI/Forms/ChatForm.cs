using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using TestGUI.UserControls;

namespace TestGUI.Forms
{
    public partial class ChatForm : Form
    {
        private string username;
        private string targetUsername;
        private bool encrypting;

        public ChatForm(string username)
        {
            InitializeComponent();
            this.username = username;

            Program.Receiver.Map("active", (response) =>
            {
                BeginInvoke(new Action(() =>
                {
                    listBox1.Controls.Clear();
                    foreach (dynamic user in response.Users)
                    {
                        if (user.Username == this.username) continue;

                        else
                        {
                            var box = new UserBox(user.Username.ToString(), user.Status.ToString());
                            box.Click += (_, __) => // action happens when i click on the username box
                            {
                                targetUsername = box.Username.ToString();
                                targetUsernameLabel.Text = targetUsername;
                                
                                listBox2.Controls.Clear();
                                
                                Program.Receiver.Network.Send(new { 
                                    Type = "private old messages", 
                                    From = username, 
                                    To = targetUsername, 
                                    requestingUser = username                                    
                                });
                            };
                            listBox1.Controls.Add(box);
                        }
                    }
                }));
            });

            // get from database all messages between the clients
            Program.Receiver.Map("private old messages", (response2) =>
            {
                BeginInvoke(new Action(() =>
                {
                    
                    
                    foreach (dynamic msg in response2.Messages)
                    {
                        if((bool)msg.Encrypted)
                        {
                            listBox2.Controls.Add(new ChatBox(msg.SenderUsername.ToString(), msg.DateSent.ToString(), NetworkHandler.Decrypt(msg.Message.ToString())));
                        }
                        else
                            listBox2.Controls.Add(new ChatBox(msg.SenderUsername.ToString(), msg.DateSent.ToString(), msg.Message.ToString()));
                    }
                }));
            });

            Program.Receiver.Map("private_message", (response) =>
            {
                BeginInvoke(new Action(() =>
                {
                    string msg = response.Message.ToString();
                    if ((bool) response.Encrypt)
                    {
                        msg = NetworkHandler.Decrypt(msg);
                    }
                    listBox2.Controls.Add(new ChatBox(response.Username.ToString(), response.SentAt.ToString(), msg));
                    
                }));
            });

            Program.Receiver.Map("BroadCast", (response) =>
            {
                BeginInvoke(new Action(() =>
                {
                    string msg = response.BroadcastMessage.ToString();

                    if ((bool) response.Encrypt)
                    {
                        listBox2.Controls.Add(new ChatBox
                        (
                        response.FromUser.ToString(),
                        response.date.ToString(),
                        NetworkHandler.Decrypt(msg)
                        ));
                    }

                    else
                    {
                        listBox2.Controls.Add(new ChatBox
                            (
                            response.FromUser.ToString(),
                            response.date.ToString(),
                            msg
                            ));
                    }
                }));
            });

            Program.Receiver.Network.Send(new { Type = "active" });
        }
        
        private void button1_Click(object sender, EventArgs e) // send a private message
        {
            if (targetUsername == null) return;
            var msg = richTextBox1.Text;
            listBox2.Controls.Add(new ChatBox(username.ToString(), DateTime.Now.ToString(), msg));

            Program.Receiver.Network.Send(new
            {
                Type = "private_message",
                From = username,
                To = targetUsername,
                SentAt = DateTime.Now.ToString(),
                Message = (encrypting) ? NetworkHandler.Encrypt(msg) : msg,
                ChattingType = "Private",
                Encrypt = encrypting
            });
        }
     

        private void BroadCast_Click(object sender, EventArgs e) // send broadcast message
        {
            // send to server the broadcast message 
            Program.Receiver.Network.Send(new { 
                Type = "BroadCast", 
                BroadCastMessage = (encrypting) ? NetworkHandler.Encrypt(richTextBox1.Text) : richTextBox1.Text, 
                From = username, 
                DateSentAt = DateTime.Now,
                Encrypt = encrypting
            });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // encryption
        {
            encrypting = !encrypting;
        }
    }
}
