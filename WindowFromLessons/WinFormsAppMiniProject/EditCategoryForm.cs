using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppMiniProject
{
	public partial class EditCategoryForm : Form
	{
		AdoDotNetService _adoDotNetService = new AdoDotNetService();
		private readonly long _categoryID;
		private readonly string _categoryName;

		public EditCategoryForm(long Id, string categoryName)
		{
			InitializeComponent();
			_categoryID = Id;
			_categoryName = categoryName;
		}

		private void EditCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void EditCategoryForm_Load(object sender, EventArgs e)
		{
			txtCreateCategoryName.Text = _categoryName;
		}

		private void btnEditCategory_Click(object sender, EventArgs e)
		{
			string categoryName = txtCreateCategoryName.Text;
			//duplicate case
			string duplicateEditQuery = @"SELECT * FROM Category WHERE CategoryName = @CategoryName AND IsActive = @IsActive
									AND CategoryId != @CategoryId";
			List<SqlParameter> duplicateEditParams = new List<SqlParameter>()
			{
				new SqlParameter("@CategoryName", categoryName),
				new SqlParameter("@IsActive", true),
				new SqlParameter("@CategoryId", _categoryID)
			};
			DataTable dt = _adoDotNetService.QueryFirstOrDefault(duplicateEditQuery, duplicateEditParams.ToArray());
			if (dt.Rows.Count > 0)
			{
				MessageBox.Show("Category Name already exists!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//txtCreateCategoryName.Text = string.Empty;
				return;
			}

			if(string.IsNullOrEmpty(categoryName))
			{
				MessageBox.Show("Pleae fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// update case
			string query = @"UPDATE Category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
			List<SqlParameter> parameters = new List<SqlParameter>()
			{
				new SqlParameter("@CategoryName", categoryName),
				new SqlParameter("@CategoryId", _categoryID)
			};
			int result = _adoDotNetService.Execute(query, parameters.ToArray());

			if (result > 0)
			{
				MessageBox.Show("Updating Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				GoToMainCategoryManagementForm();
				return;
			}
			MessageBox.Show("Updating Fail!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnBack_Click_1(object sender, EventArgs e)
		{
			GoToMainCategoryManagementForm();
		}

		private void GoToMainCategoryManagementForm()
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide();
		}
	}
}
