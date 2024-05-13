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
	public partial class editBlog : Form
	{
		AdoDotNetServices _adoDotNetServices = new AdoDotNetServices();

		private readonly long _blogId;
		private readonly string _blogTitle;
		private readonly string _blogAuthor;
		private readonly string _blogContent;
		public editBlog(long id, string blogTitle, string blogAuthor, string blogContent)
		{
			InitializeComponent();
			_blogId = id;
			_blogTitle = blogTitle;
			_blogAuthor = blogAuthor;
			_blogContent = blogContent;
		}

		private void editBlog_Load(object sender, EventArgs e)
		{
			txtBlogEditTitle.Text = _blogTitle;
			txtBlogEditAuthor.Text = _blogAuthor;
			txtBlogEditContent.Text	= _blogContent;
		}

		private void btnSaveEditBlog_Click(object sender, EventArgs e)
		{
			try {
				string blogEidtTitle = txtBlogEditTitle.Text;
				string blogEditAuthor = txtBlogEditAuthor.Text;
				string blogEditContent = txtBlogEditContent.Text;

				//duplicate case
				string duplicateEditBlogQuery = @"SELECT [BlogId]
				  ,[BlogTitle]
				  ,[BlogAuthor]
				  ,[BlogContent]
				FROM [dbo].[Blog] WHERE BlogTitle = @BlogTitle AND BlogAuthor = @BlogAuthor AND BlogContent = @BlogContent AND BlogId != @BlogId";
				List<SqlParameter> duplicateEditBlogPara = new List<SqlParameter>()
					{
						new SqlParameter("@BlogTitle", blogEidtTitle),
						new SqlParameter("@BlogAuthor", blogEditAuthor),
						new SqlParameter("@BlogContent", blogEditContent),
						new SqlParameter("@BlogId", _blogId)
					};

				DataTable duplicateEditResult = _adoDotNetServices.QueryFirstOrDefault(duplicateEditBlogQuery, duplicateEditBlogPara.ToArray());
				if (duplicateEditResult.Rows.Count > 0)
				{
					MessageBox.Show("This Blog data are already exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (string.IsNullOrEmpty(blogEidtTitle) || string.IsNullOrEmpty(blogEditAuthor) || string.IsNullOrEmpty(blogEditContent))
				{
					MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				//update case
				string updateEditBlogQuery = @"UPDATE Blog SET BlogTitle = @BlogTitle, BlogAuthor = @BlogAuthor, BlogContent = @BlogContent WHERE BlogId = @BlogId";
				List<SqlParameter> updateEditBlogPara = new List<SqlParameter>()
				{
					new SqlParameter("@BlogTitle", blogEidtTitle),
					new SqlParameter("@BlogAuthor", blogEditAuthor),
					new SqlParameter("@BlogContent", blogEditContent),
					new SqlParameter("@BlogId", _blogId)
				};
				int updateEidtResult = _adoDotNetServices.Execute(updateEditBlogQuery, updateEditBlogPara.ToArray());
				if (updateEidtResult > 0)
				{
					MessageBox.Show("Update is successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					BackToMainBlog();
					return;
				}
				MessageBox.Show("Updating is fail.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			BackToMainBlog();
		}

		private void editBlog_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BackToMainBlog()
		{
			Form1 form = new Form1();
			form.Show();
			this.Hide();
		}
	}
}
