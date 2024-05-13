namespace KhunBaHan.SampleWindowFormAppDay_8
{
	partial class Form1
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
			lblEmail = new Label();
			lblPassword = new Label();
			txtEmail = new TextBox();
			txtPassword = new TextBox();
			lblLogin = new Button();
			lblEmailError = new Label();
			lblPasswordError = new Label();
			SuspendLayout();
			// 
			// lblEmail
			// 
			lblEmail.AutoSize = true;
			lblEmail.Location = new Point(66, 81);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new Size(36, 15);
			lblEmail.TabIndex = 0;
			lblEmail.Text = "Email";
			// 
			// lblPassword
			// 
			lblPassword.AutoSize = true;
			lblPassword.Location = new Point(66, 144);
			lblPassword.Name = "lblPassword";
			lblPassword.Size = new Size(57, 15);
			lblPassword.TabIndex = 1;
			lblPassword.Text = "Password";
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(137, 78);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(137, 23);
			txtEmail.TabIndex = 2;
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(137, 136);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(137, 23);
			txtPassword.TabIndex = 3;
			// 
			// lblLogin
			// 
			lblLogin.Location = new Point(167, 196);
			lblLogin.Name = "lblLogin";
			lblLogin.Size = new Size(75, 23);
			lblLogin.TabIndex = 4;
			lblLogin.Text = "Login";
			lblLogin.UseVisualStyleBackColor = true;
			lblLogin.Click += lblLogin_Click;
			// 
			// lblEmailError
			// 
			lblEmailError.AutoSize = true;
			lblEmailError.ForeColor = Color.Red;
			lblEmailError.Location = new Point(137, 105);
			lblEmailError.Name = "lblEmailError";
			lblEmailError.Size = new Size(118, 15);
			lblEmailError.TabIndex = 5;
			lblEmailError.Text = "Please fill your email.";
			// 
			// lblPasswordError
			// 
			lblPasswordError.AutoSize = true;
			lblPasswordError.ForeColor = Color.Red;
			lblPasswordError.Location = new Point(137, 162);
			lblPasswordError.Name = "lblPasswordError";
			lblPasswordError.Size = new Size(139, 15);
			lblPasswordError.TabIndex = 6;
			lblPasswordError.Text = "Please fill your password.";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(389, 296);
			Controls.Add(lblPasswordError);
			Controls.Add(lblEmailError);
			Controls.Add(lblLogin);
			Controls.Add(txtPassword);
			Controls.Add(txtEmail);
			Controls.Add(lblPassword);
			Controls.Add(lblEmail);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblEmail;
		private Label lblPassword;
		private TextBox txtEmail;
		private TextBox txtPassword;
		private Button lblLogin;
		private Label lblEmailError;
		private Label lblPasswordError;
	}
}