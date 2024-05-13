namespace WinFormsAppMiniProject
{
	partial class EditCategoryForm
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
			lblEditCategoryForm = new Label();
			btnBack = new Button();
			panel1 = new Panel();
			btnEditCategory = new Button();
			txtCreateCategoryName = new TextBox();
			lblEditCategoryName = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblEditCategoryForm
			// 
			lblEditCategoryForm.AutoSize = true;
			lblEditCategoryForm.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEditCategoryForm.Location = new Point(295, 26);
			lblEditCategoryForm.Name = "lblEditCategoryForm";
			lblEditCategoryForm.Size = new Size(225, 32);
			lblEditCategoryForm.TabIndex = 1;
			lblEditCategoryForm.Text = "Edit Category Form";
			// 
			// btnBack
			// 
			btnBack.BackColor = Color.Lime;
			btnBack.ForeColor = Color.Black;
			btnBack.Location = new Point(23, 66);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(75, 31);
			btnBack.TabIndex = 3;
			btnBack.Text = "Back";
			btnBack.UseVisualStyleBackColor = false;
			btnBack.Click += btnBack_Click_1;
			// 
			// panel1
			// 
			panel1.Controls.Add(btnEditCategory);
			panel1.Controls.Add(txtCreateCategoryName);
			panel1.Controls.Add(lblEditCategoryName);
			panel1.Location = new Point(3, 103);
			panel1.Name = "panel1";
			panel1.Size = new Size(861, 298);
			panel1.TabIndex = 4;
			// 
			// btnEditCategory
			// 
			btnEditCategory.BackColor = Color.Lime;
			btnEditCategory.Location = new Point(391, 109);
			btnEditCategory.Name = "btnEditCategory";
			btnEditCategory.Size = new Size(102, 31);
			btnEditCategory.TabIndex = 2;
			btnEditCategory.Text = "Save";
			btnEditCategory.UseVisualStyleBackColor = false;
			btnEditCategory.Click += btnEditCategory_Click;
			// 
			// txtCreateCategoryName
			// 
			txtCreateCategoryName.Location = new Point(292, 53);
			txtCreateCategoryName.Name = "txtCreateCategoryName";
			txtCreateCategoryName.Size = new Size(201, 23);
			txtCreateCategoryName.TabIndex = 1;
			// 
			// lblEditCategoryName
			// 
			lblEditCategoryName.AutoSize = true;
			lblEditCategoryName.Location = new Point(165, 56);
			lblEditCategoryName.Name = "lblEditCategoryName";
			lblEditCategoryName.Size = new Size(113, 15);
			lblEditCategoryName.TabIndex = 0;
			lblEditCategoryName.Text = "Edit Category Name";
			// 
			// EditCategoryForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(869, 403);
			Controls.Add(panel1);
			Controls.Add(btnBack);
			Controls.Add(lblEditCategoryForm);
			Name = "EditCategoryForm";
			Text = "EditCategoryForm";
			FormClosed += EditCategoryForm_FormClosed;
			Load += EditCategoryForm_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblEditCategoryForm;
		private Button btnBack;
		private Panel panel1;
		private Button btnEditCategory;
		private TextBox txtCreateCategoryName;
		private Label lblEditCategoryName;
	}
}