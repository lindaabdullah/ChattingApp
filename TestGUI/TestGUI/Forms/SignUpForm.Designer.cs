namespace TestGUI.Forms
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewSSN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NewAddress = new System.Windows.Forms.TextBox();
            this.NewEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.NewSurname = new System.Windows.Forms.TextBox();
            this.NewUsername = new System.Windows.Forms.TextBox();
            this.NewName = new System.Windows.Forms.TextBox();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.SSNLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.UsernameBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.Controls.Add(this.label3);
            this.UsernameBox.Controls.Add(this.NewSSN);
            this.UsernameBox.Controls.Add(this.button1);
            this.UsernameBox.Controls.Add(this.label1);
            this.UsernameBox.Controls.Add(this.NewAddress);
            this.UsernameBox.Controls.Add(this.NewEmail);
            this.UsernameBox.Controls.Add(this.label2);
            this.UsernameBox.Controls.Add(this.EmailLabel);
            this.UsernameBox.Controls.Add(this.UsernameLabel);
            this.UsernameBox.Controls.Add(this.NewSurname);
            this.UsernameBox.Controls.Add(this.NewUsername);
            this.UsernameBox.Controls.Add(this.NewName);
            this.UsernameBox.Controls.Add(this.NewPassword);
            this.UsernameBox.Controls.Add(this.SSNLabel);
            this.UsernameBox.Controls.Add(this.PasswordLabel);
            this.UsernameBox.Location = new System.Drawing.Point(245, 12);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(286, 408);
            this.UsernameBox.TabIndex = 5;
            this.UsernameBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "SSN";
            // 
            // NewSSN
            // 
            this.NewSSN.Location = new System.Drawing.Point(105, 11);
            this.NewSSN.Name = "NewSSN";
            this.NewSSN.Size = new System.Drawing.Size(155, 22);
            this.NewSSN.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Sign up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Address";
            // 
            // NewAddress
            // 
            this.NewAddress.Location = new System.Drawing.Point(105, 325);
            this.NewAddress.Name = "NewAddress";
            this.NewAddress.Size = new System.Drawing.Size(155, 22);
            this.NewAddress.TabIndex = 14;
            // 
            // NewEmail
            // 
            this.NewEmail.Location = new System.Drawing.Point(105, 267);
            this.NewEmail.Name = "NewEmail";
            this.NewEmail.Size = new System.Drawing.Size(155, 22);
            this.NewEmail.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Email";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(33, 220);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(61, 16);
            this.EmailLabel.TabIndex = 11;
            this.EmailLabel.Text = "Surname";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(15, 49);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(70, 16);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username";
            // 
            // NewSurname
            // 
            this.NewSurname.Location = new System.Drawing.Point(105, 217);
            this.NewSurname.Name = "NewSurname";
            this.NewSurname.Size = new System.Drawing.Size(155, 22);
            this.NewSurname.TabIndex = 10;
            // 
            // NewUsername
            // 
            this.NewUsername.Location = new System.Drawing.Point(105, 49);
            this.NewUsername.Name = "NewUsername";
            this.NewUsername.Size = new System.Drawing.Size(155, 22);
            this.NewUsername.TabIndex = 0;
            // 
            // NewName
            // 
            this.NewName.Location = new System.Drawing.Point(105, 159);
            this.NewName.Name = "NewName";
            this.NewName.Size = new System.Drawing.Size(155, 22);
            this.NewName.TabIndex = 9;
            // 
            // NewPassword
            // 
            this.NewPassword.Location = new System.Drawing.Point(105, 97);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Size = new System.Drawing.Size(155, 22);
            this.NewPassword.TabIndex = 7;
            // 
            // SSNLabel
            // 
            this.SSNLabel.AutoSize = true;
            this.SSNLabel.Location = new System.Drawing.Point(33, 162);
            this.SSNLabel.Name = "SSNLabel";
            this.SSNLabel.Size = new System.Drawing.Size(44, 16);
            this.SSNLabel.TabIndex = 8;
            this.SSNLabel.Text = "Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(18, 97);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(67, 16);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.UsernameBox);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.UsernameBox.ResumeLayout(false);
            this.UsernameBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UsernameBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox NewUsername;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox NewPassword;
        private System.Windows.Forms.Label SSNLabel;
        private System.Windows.Forms.TextBox NewName;
        private System.Windows.Forms.TextBox NewSurname;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewAddress;
        private System.Windows.Forms.TextBox NewEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NewSSN;
        private System.Windows.Forms.Button button2;
    }
}