namespace BlogWinFormsAppMiniProject
{
	partial class CreateBlog
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
			lblCreateBlog = new Label();
			panel1 = new Panel();
			btnBack = new Button();
			btnSaveCreatBlog = new Button();
			txtBlogAuthor = new TextBox();
			txtBlogContent = new TextBox();
			txtBlogTitle = new TextBox();
			lblBlogAuthor = new Label();
			lblBlogContent = new Label();
			lblBlogTitle = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblCreateBlog
			// 
			lblCreateBlog.AutoSize = true;
			lblCreateBlog.BackColor = Color.FromArgb(255, 128, 128);
			lblCreateBlog.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			lblCreateBlog.ForeColor = Color.White;
			lblCreateBlog.Location = new Point(258, 27);
			lblCreateBlog.Name = "lblCreateBlog";
			lblCreateBlog.Size = new Size(220, 47);
			lblCreateBlog.TabIndex = 0;
			lblCreateBlog.Text = "Create Blog";
			// 
			// panel1
			// 
			panel1.Controls.Add(btnBack);
			panel1.Controls.Add(btnSaveCreatBlog);
			panel1.Controls.Add(txtBlogAuthor);
			panel1.Controls.Add(txtBlogContent);
			panel1.Controls.Add(txtBlogTitle);
			panel1.Controls.Add(lblBlogAuthor);
			panel1.Controls.Add(lblBlogContent);
			panel1.Controls.Add(lblBlogTitle);
			panel1.Location = new Point(6, 81);
			panel1.Name = "panel1";
			panel1.Size = new Size(728, 288);
			panel1.TabIndex = 1;
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.FromArgb(255, 128, 128);
			btnBack.ForeColor = Color.White;
			btnBack.Location = new Point(252, 204);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(86, 36);
			btnBack.TabIndex = 2;
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// btnSaveCreatBlog
			// 
			btnSaveCreatBlog.BackColor = Color.FromArgb(255, 128, 128);
			btnSaveCreatBlog.ForeColor = Color.White;
			btnSaveCreatBlog.Location = new Point(382, 204);
			btnSaveCreatBlog.Name = "btnSaveCreatBlog";
			btnSaveCreatBlog.Size = new Size(90, 36);
			btnSaveCreatBlog.TabIndex = 6;
			btnSaveCreatBlog.Text = "Save";
			btnSaveCreatBlog.UseVisualStyleBackColor = false;
			btnSaveCreatBlog.Click += btnSaveCreatBlog_Click;
			// 
			// txtBlogAuthor
			// 
			txtBlogAuthor.Location = new Point(236, 86);
			txtBlogAuthor.Name = "txtBlogAuthor";
			txtBlogAuthor.Size = new Size(281, 23);
			txtBlogAuthor.TabIndex = 5;
			// 
			// txtBlogContent
			// 
			txtBlogContent.Location = new Point(236, 150);
			txtBlogContent.Name = "txtBlogContent";
			txtBlogContent.Size = new Size(281, 23);
			txtBlogContent.TabIndex = 4;
			// 
			// txtBlogTitle
			// 
			txtBlogTitle.Location = new Point(236, 21);
			txtBlogTitle.Name = "txtBlogTitle";
			txtBlogTitle.Size = new Size(281, 23);
			txtBlogTitle.TabIndex = 3;
			// 
			// lblBlogAuthor
			// 
			lblBlogAuthor.AutoSize = true;
			lblBlogAuthor.Location = new Point(130, 86);
			lblBlogAuthor.Name = "lblBlogAuthor";
			lblBlogAuthor.Size = new Size(71, 15);
			lblBlogAuthor.TabIndex = 2;
			lblBlogAuthor.Text = "Blog Author";
			// 
			// lblBlogContent
			// 
			lblBlogContent.AutoSize = true;
			lblBlogContent.Location = new Point(130, 150);
			lblBlogContent.Name = "lblBlogContent";
			lblBlogContent.Size = new Size(77, 15);
			lblBlogContent.TabIndex = 1;
			lblBlogContent.Text = "Blog Content";
			// 
			// lblBlogTitle
			// 
			lblBlogTitle.AutoSize = true;
			lblBlogTitle.Location = new Point(130, 24);
			lblBlogTitle.Name = "lblBlogTitle";
			lblBlogTitle.Size = new Size(56, 15);
			lblBlogTitle.TabIndex = 0;
			lblBlogTitle.Text = "Blog Title";
			// 
			// CreateBlog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(736, 369);
			Controls.Add(panel1);
			Controls.Add(lblCreateBlog);
			Name = "CreateBlog";
			Text = "CreateBlog";
			FormClosed += CreateBlog_FormClosed;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblCreateBlog;
		private Panel panel1;
		private TextBox txtBlogAuthor;
		private TextBox txtBlogContent;
		private TextBox txtBlogTitle;
		private Label lblBlogAuthor;
		private Label lblBlogContent;
		private Label lblBlogTitle;
		private Button btnSaveCreatBlog;
		private Button btnBack;
	}
}