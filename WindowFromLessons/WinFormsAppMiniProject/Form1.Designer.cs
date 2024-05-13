namespace WinFormsAppMiniProject
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
			panel1 = new Panel();
			btnCreateCategory = new Button();
			dgv1 = new DataGridView();
			lblCategoryList = new Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(btnCreateCategory);
			panel1.Controls.Add(dgv1);
			panel1.Controls.Add(lblCategoryList);
			panel1.Location = new Point(1, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(800, 446);
			panel1.TabIndex = 0;
			// 
			// btnCreateCategory
			// 
			btnCreateCategory.BackColor = Color.Lime;
			btnCreateCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCreateCategory.ForeColor = Color.Black;
			btnCreateCategory.Location = new Point(7, 57);
			btnCreateCategory.Name = "btnCreateCategory";
			btnCreateCategory.Size = new Size(129, 34);
			btnCreateCategory.TabIndex = 2;
			btnCreateCategory.Text = "CreateCategory";
			btnCreateCategory.UseVisualStyleBackColor = false;
			btnCreateCategory.Click += btnCreateCategory_Click;
			// 
			// dgv1
			// 
			dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv1.Location = new Point(-2, 99);
			dgv1.Name = "dgv1";
			dgv1.Size = new Size(801, 347);
			dgv1.TabIndex = 1;
			dgv1.CellContentClick += dgv1_CellContentClick;
			// 
			// lblCategoryList
			// 
			lblCategoryList.AutoSize = true;
			lblCategoryList.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			lblCategoryList.Location = new Point(273, 7);
			lblCategoryList.Name = "lblCategoryList";
			lblCategoryList.Size = new Size(207, 45);
			lblCategoryList.TabIndex = 0;
			lblCategoryList.Text = "Category List";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label lblCategoryList;
		private DataGridView dgv1;
		private Button btnCreateCategory;
	}
}
