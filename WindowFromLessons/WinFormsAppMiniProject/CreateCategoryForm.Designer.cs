namespace WinFormsAppMiniProject
{
	partial class CreateCategoryForm
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
			lblCreateCategoryForm = new Label();
			panel1 = new Panel();
			btnCreateCategory = new Button();
			txtCreateCategoryName = new TextBox();
			lblCreateCategoryName = new Label();
			btnBack = new Button();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblCreateCategoryForm
			// 
			lblCreateCategoryForm.AutoSize = true;
			lblCreateCategoryForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCreateCategoryForm.Location = new Point(241, 18);
			lblCreateCategoryForm.Name = "lblCreateCategoryForm";
			lblCreateCategoryForm.Size = new Size(256, 32);
			lblCreateCategoryForm.TabIndex = 0;
			lblCreateCategoryForm.Text = "Create Category Form";
			// 
			// panel1
			// 
			panel1.Controls.Add(btnCreateCategory);
			panel1.Controls.Add(txtCreateCategoryName);
			panel1.Controls.Add(lblCreateCategoryName);
			panel1.Location = new Point(4, 89);
			panel1.Name = "panel1";
			panel1.Size = new Size(672, 265);
			panel1.TabIndex = 1;
			// 
			// btnCreateCategory
			// 
			btnCreateCategory.BackColor = Color.Lime;
			btnCreateCategory.Location = new Point(391, 109);
			btnCreateCategory.Name = "btnCreateCategory";
			btnCreateCategory.Size = new Size(102, 31);
			btnCreateCategory.TabIndex = 2;
			btnCreateCategory.Text = "Save";
			btnCreateCategory.UseVisualStyleBackColor = false;
			btnCreateCategory.Click += btnCreateCategory_Click;
			// 
			// txtCreateCategoryName
			// 
			txtCreateCategoryName.Location = new Point(292, 53);
			txtCreateCategoryName.Name = "txtCreateCategoryName";
			txtCreateCategoryName.Size = new Size(201, 23);
			txtCreateCategoryName.TabIndex = 1;
			// 
			// lblCreateCategoryName
			// 
			lblCreateCategoryName.AutoSize = true;
			lblCreateCategoryName.Location = new Point(165, 56);
			lblCreateCategoryName.Name = "lblCreateCategoryName";
			lblCreateCategoryName.Size = new Size(127, 15);
			lblCreateCategoryName.TabIndex = 0;
			lblCreateCategoryName.Text = "Create Category Name";
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.Lime;
			btnBack.ForeColor = Color.Black;
			btnBack.Location = new Point(18, 42);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(75, 31);
			btnBack.TabIndex = 2;
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click;
			// 
			// CreateCategoryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(676, 358);
			Controls.Add(btnBack);
			Controls.Add(panel1);
			Controls.Add(lblCreateCategoryForm);
			Name = "CreateCategoryForm";
			Text = "CreateCategoryForm";
			FormClosed += CreateCategoryForm_FormClosed;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblCreateCategoryForm;
		private Panel panel1;
		private Button btnCreateCategory;
		private TextBox txtCreateCategoryName;
		private Label lblCreateCategoryName;
		private Button btnBack;
	}
}