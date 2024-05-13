using System.Data.SqlClient;
using WinFormsAppMiniProject.Models;

namespace WinFormsAppMiniProject
{
	public partial class Form1 : Form
	{

		AdoDotNetService _adoDotNetService = new AdoDotNetService();
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			fetchData();

			try
			{
				DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn()
				{
					Text = "Edit",
					UseColumnTextForButtonValue = true
				};
				editBtn.DefaultCellStyle.BackColor = Color.Green;
				dgv1.Columns.Add(editBtn);

				DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn()
				{
					Text = "Delete",
					UseColumnTextForButtonValue = true
				};
				deleteBtn.DefaultCellStyle.BackColor = Color.Red;
				dgv1.Columns.Add(deleteBtn);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void btnCreateCategory_Click(object sender, EventArgs e)
		{
			CreateCategoryForm createCategoryForm = new CreateCategoryForm();
			createCategoryForm.Show();
			this.Hide();
		}

		private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			long id = Convert.ToInt64(dgv1.Rows[e.RowIndex].Cells[0].Value);

			//edit case
			if (e.ColumnIndex == 2)
			{
				string categoryName = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[1].Value)!;
				EditCategoryForm editCategoryForm = new EditCategoryForm(id, categoryName);
				editCategoryForm.Show();
				this.Hide();
			}

			//delete case
			if (e.ColumnIndex == 3)
				try
				{
					DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					if (dialogResult == DialogResult.OK)
					{
						string query = @"DELETE FROM Category WHERE CategoryId = @CategoryId";
						List<SqlParameter> parameters = new List<SqlParameter>()
						{
							new SqlParameter("@CategoryId", id)
						};
						int result = _adoDotNetService.Execute(query, parameters.ToArray());

						if (result > 0)
						{
							MessageBox.Show("Deleting Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
							fetchData();
							return;
						}
						MessageBox.Show("Deleting Fail!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}

		private void fetchData()
		{
			try
			{
				string query = @"SELECT [CategoryId]
							  ,[CategoryName]
							  ,[IsActive]
						  FROM [dbo].[Category] WHERE IsActive=@IsActive";
				List<SqlParameter> parameters = new List<SqlParameter>()
				{
					new SqlParameter("@IsActive", true)
				};
				List<CategoryModel> lst = _adoDotNetService.Query<CategoryModel>(query, parameters.ToArray());

				dgv1.DataSource = lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
