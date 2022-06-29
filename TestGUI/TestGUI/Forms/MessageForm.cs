using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGUI.Forms
{
    public partial class MessageForm : Form
    {
        private Form source;

        public MessageForm(Form source, string message)
        {
            InitializeComponent();
            this.source = source;
            LabelText = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source.Show();
            this.Close();
        }

        public string LabelText
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
    }
}
