namespace BlogWinFormsAppMiniProject
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			panel1 = new Panel();
			dataGridView1 = new DataGridView();
			btnCreateBlog = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.FromArgb(255, 128, 128);
			label1.Font = new Font("Segoe UI Black", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(262, 12);
			label1.Name = "label1";
			label1.Size = new Size(178, 50);
			label1.TabIndex = 0;
			label1.Text = "Blog List";
			// 
			// panel1
			// 
			panel1.Controls.Add(dataGridView1);
			panel1.Location = new Point(2, 92);
			panel1.Name = "panel1";
			panel1.Size = new Size(731, 303);
			panel1.TabIndex = 1;
			// 
			// dataGridView1
			// 
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(3, 3);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(725, 297);
			dataGridView1.TabIndex = 0;
			dataGridView1.CellContentClick += dataGridView1_CellContentClick;
			// 
			// btnCreateBlog
			// 
			btnCreateBlog.BackColor = Color.FromArgb(255, 128, 128);
			btnCreateBlog.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			btnCreateBlog.ForeColor = Color.White;
			btnCreateBlog.Location = new Point(605, 21);
			btnCreateBlog.Name = "btnCreateBlog";
			btnCreateBlog.Size = new Size(125, 45);
			btnCreateBlog.TabIndex = 2;
			btnCreateBlog.Text = "Create Blog";
			btnCreateBlog.UseVisualStyleBackColor = false;
			btnCreateBlog.Click += btnCreateBlog_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(734, 395);
			Controls.Add(btnCreateBlog);
			Controls.Add(panel1);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Panel panel1;
		private DataGridView dataGridView1;
		private Button btnCreateBlog;
	}
}
