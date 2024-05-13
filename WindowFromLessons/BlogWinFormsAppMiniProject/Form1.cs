using BlogWinFormsAppMiniProject.Models;
using BlogWinFormsAppMiniProject.Services;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BlogWinFormsAppMiniProject
{
	public partial class Form1 : Form
	{

		AdoDotNetServices _adoDotNetServices = new AdoDotNetServices();
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			fetchData();

			DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn()
			{
				Text = "Edit",
				UseColumnTextForButtonValue = true
			};
			editBtn.DefaultCellStyle.BackColor = Color.Green;
			dataGridView1.Columns.Add(editBtn);

			DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn()
			{
				Text = "Delete",
				UseColumnTextForButtonValue = true
			};
			deleteBtn.DefaultCellStyle.BackColor = Color.Red;
			dataGridView1.Columns.Add(deleteBtn);
		}

		private void btnCreateBlog_Click(object sender, EventArgs e)
		{
			CreateBlog createBlog = new CreateBlog();
			createBlog.Show();
			this.Hide();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			long id = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

			if (e.ColumnIndex == 4) {
				string blogTitle = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)!;
				string blogAuthor = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value)!;
				string blogContent = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value)!;
				editBlog blogEdit = new editBlog(id, blogTitle, blogAuthor, blogContent);
				blogEdit.Show();
				this.Hide();
			}

			if (e.ColumnIndex == 5)
			{
				try
				{
					DialogResult dialogResult = MessageBox.Show("Are you sure want to delet this record?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					if (dialogResult == DialogResult.OK)
					{
						string deleteBlogListQuery = @"DELETE FROM Blog WHERE BlogId = @BlogId";
						List<SqlParameter> deleteBlogListPara = new List<SqlParameter>()
						{
							new SqlParameter("@BlogId", id)
						};
						int deleteBlogListResult = _adoDotNetServices.Execute(deleteBlogListQuery, deleteBlogListPara.ToArray());

						if(deleteBlogListResult > 0)
						{
							MessageBox.Show("Deleting is Successfully.", "Informatin", MessageBoxButtons.OK, MessageBoxIcon.Information);
							fetchData();
							return;
						}
						MessageBox.Show("Deletiing is not Successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex) {
					throw new Exception(ex.Message);
				}
			}
		}

		private void fetchData() {
			try {
				string fetchQuery = @"SELECT [BlogId]
					,[BlogTitle]
					,[BlogAuthor]
					,[BlogContent]
				FROM [dbo].[Blog]";
				List<SqlParameter> fetchPara = new List<SqlParameter>();
				List<BlogModels> blogResult = _adoDotNetServices.Query<BlogModels>(fetchQuery, fetchPara.ToArray());

				dataGridView1.DataSource = blogResult;
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
	}
}
