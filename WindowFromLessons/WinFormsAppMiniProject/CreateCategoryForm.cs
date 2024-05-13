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
	public partial class CreateCategoryForm : Form
	{
		AdoDotNetService _adoDotNetService = new AdoDotNetService();
		public CreateCategoryForm()
		{
			InitializeComponent();
		}

		private void CreateCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void btnCreateCategory_Click(object sender, EventArgs e)
		{
			try
			{
				string categoryName = txtCreateCategoryName.Text;

				string duplicateQuery = @"SELECT [CategoryId]
										,[CategoryName]
										,[IsActive]
									FROM [dbo].[Category] WHERE CategoryName=@CategoryName AND IsActive=@IsActive";
				List<SqlParameter> duplicatePara = new List<SqlParameter>()
				{
					new SqlParameter("@CategoryName", categoryName),
					new SqlParameter("@IsActive", true)
				};
				DataTable dt = _adoDotNetService.QueryFirstOrDefault(duplicateQuery, duplicatePara.ToArray());

				if (dt.Rows.Count > 0)
				{
					MessageBox.Show("Category Name is already exit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtCreateCategoryName.Text = string.Empty;
					return;
				}

				if (string.IsNullOrEmpty(categoryName))
				{
					MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string executeQuery = @"INSERT INTO Category (CategoryName, IsActive) VALUES (@CategoryName, @IsActive)";
				List<SqlParameter> executePara = new List<SqlParameter>()
				{
					new SqlParameter("@CategoryName", categoryName),
					new SqlParameter("@IsActive", true)
				};

				int result = _adoDotNetService.Execute(executeQuery, executePara.ToArray());

				if (result > 0)
				{
					MessageBox.Show("Create Category Name is Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					GoToMainCategoryManagementForm();
					return;
				}

				MessageBox.Show("Creating Fail!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
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
