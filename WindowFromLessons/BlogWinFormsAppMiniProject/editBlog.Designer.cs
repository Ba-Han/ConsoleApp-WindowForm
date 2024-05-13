namespace BlogWinFormsAppMiniProject
{
	partial class editBlog
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
			lblEditBlog = new Label();
			panel1 = new Panel();
			btnBack = new Button();
			btnSaveEditBlog = new Button();
			txtBlogEditAuthor = new TextBox();
			txtBlogEditContent = new TextBox();
			txtBlogEditTitle = new TextBox();
			lblBlogAuthor = new Label();
			lblBlogContent = new Label();
			lblBlogTitle = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblEditBlog
			// 
			lblEditBlog.AutoSize = true;
			lblEditBlog.BackColor = Color.FromArgb(255, 128, 128);
			lblEditBlog.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			lblEditBlog.ForeColor = Color.White;
			lblEditBlog.Location = new Point(259, 25);
			lblEditBlog.Name = "lblEditBlog";
			lblEditBlog.Size = new Size(175, 47);
			lblEditBlog.TabIndex = 1;
			lblEditBlog.Text = "Edit Blog";
			// 
			// panel1
			// 
			panel1.Controls.Add(btnBack);
			panel1.Controls.Add(btnSaveEditBlog);
			panel1.Controls.Add(txtBlogEditAuthor);
			panel1.Controls.Add(txtBlogEditContent);
			panel1.Controls.Add(txtBlogEditTitle);
			panel1.Controls.Add(lblBlogAuthor);
			panel1.Controls.Add(lblBlogContent);
			panel1.Controls.Add(lblBlogTitle);
			panel1.Location = new Point(2, 93);
			panel1.Name = "panel1";
			panel1.Size = new Size(728, 288);
			panel1.TabIndex = 2;
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
			// btnSaveEditBlog
			// 
			btnSaveEditBlog.BackColor = Color.FromArgb(255, 128, 128);
			btnSaveEditBlog.ForeColor = Color.White;
			btnSaveEditBlog.Location = new Point(382, 204);
			btnSaveEditBlog.Name = "btnSaveEditBlog";
			btnSaveEditBlog.Size = new Size(90, 36);
			btnSaveEditBlog.TabIndex = 6;
			btnSaveEditBlog.Text = "Save";
			btnSaveEditBlog.UseVisualStyleBackColor = false;
			btnSaveEditBlog.Click += btnSaveEditBlog_Click;
			// 
			// txtBlogEditAuthor
			// 
			txtBlogEditAuthor.Location = new Point(236, 86);
			txtBlogEditAuthor.Name = "txtBlogEditAuthor";
			txtBlogEditAuthor.Size = new Size(281, 23);
			txtBlogEditAuthor.TabIndex = 5;
			// 
			// txtBlogEditContent
			// 
			txtBlogEditContent.Location = new Point(236, 150);
			txtBlogEditContent.Name = "txtBlogEditContent";
			txtBlogEditContent.Size = new Size(281, 23);
			txtBlogEditContent.TabIndex = 4;
			// 
			// txtBlogEditTitle
			// 
			txtBlogEditTitle.Location = new Point(236, 21);
			txtBlogEditTitle.Name = "txtBlogEditTitle";
			txtBlogEditTitle.Size = new Size(281, 23);
			txtBlogEditTitle.TabIndex = 3;
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
			// editBlog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(733, 387);
			Controls.Add(panel1);
			Controls.Add(lblEditBlog);
			Name = "editBlog";
			Text = "editBlog";
			FormClosed += editBlog_FormClosed;
			Load += editBlog_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblEditBlog;
		private Panel panel1;
		private Button btnBack;
		private Button btnSaveEditBlog;
		private TextBox txtBlogEditAuthor;
		private TextBox txtBlogEditContent;
		private TextBox txtBlogEditTitle;
		private Label lblBlogAuthor;
		private Label lblBlogContent;
		private Label lblBlogTitle;
	}
}