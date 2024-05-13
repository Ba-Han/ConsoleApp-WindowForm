using BlogWinFormsAppMiniProject.Services;
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

namespace BlogWinFormsAppMiniProject
{
	public partial class CreateBlog : Form
	{

		AdoDotNetServices _adoDotNetServices = new AdoDotNetServices();
		public CreateBlog()
		{
			InitializeComponent();
		}

		private void btnSaveCreatBlog_Click(object sender, EventArgs e)
		{
			try
			{
				string blogTilte = txtBlogTitle.Text;
				string blogAuthor = txtBlogAuthor.Text;
				string blogContent = txtBlogContent.Text;

				//duplicate case
				string duplicateCreateBlogQuery = @"SELECT [BlogId]
				  ,[BlogTitle]
				  ,[BlogAuthor]
				  ,[BlogContent]
				FROM [dbo].[Blog] WHERE BlogTitle=@BlogTitle AND BlogAuthor=@BlogAuthor AND BlogContent=@BlogContent";
				List<SqlParameter> duplicateCreateBlogPara = new List<SqlParameter>()
				{
					new SqlParameter("@BlogTitle", blogTilte),
					new SqlParameter("@BlogAuthor", blogAuthor),
					new SqlParameter("@BlogContent", blogContent)
				};

				DataTable duplicateResult = _adoDotNetServices.QueryFirstOrDefault(duplicateCreateBlogQuery, duplicateCreateBlogPara.ToArray());
				if (duplicateResult.Rows.Count > 0)
				{
					MessageBox.Show("This Blog fields are already exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (string.IsNullOrEmpty(blogTilte) || string.IsNullOrEmpty(blogAuthor) || string.IsNullOrEmpty(blogContent))
				{
					MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				//Insert case
				string insertCreateBlogQuery = @"INSERT INTO Blog (BlogTitle, BlogAuthor, BlogContent) VALUES (@BlogTitle, @BlogAuthor, @BlogContent)";
				List<SqlParameter> insertCreateBlogPara = new List<SqlParameter>()
				{
					new SqlParameter("@BlogTitle", blogTilte),
					new SqlParameter("@BlogAuthor", blogAuthor),
					new SqlParameter("@BlogContent", blogContent)
				};

				int resultCreateBlog = _adoDotNetServices.Execute(insertCreateBlogQuery, insertCreateBlogPara.ToArray());
				if (resultCreateBlog > 0)
				{
					MessageBox.Show("Creating Blog data are successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					BackToMainBlog();
					return;
				}
				MessageBox.Show("Creating fail.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			BackToMainBlog();
		}

		private void BackToMainBlog()
		{
			Form1 form = new Form1();
			form.Show();
			this.Hide();
		}

		private void CreateBlog_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
