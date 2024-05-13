using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KhunBaHan.SampleWindowFormAppDay_8
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private readonly string _connStr = "Data Source=DESKTOP-B0SF9L0\\MSSQLSERVERDEV;Initial Catalog=khunbahan;User ID=bhbackend;Password=123;TrustServerCertificate=True";

		private void lblLogin_Click(object sender, EventArgs e)
		{
			try
			{
				string userEmail = txtEmail.Text;
				string userPassword = txtPassword.Text;

				SqlConnection conn = new SqlConnection(_connStr);
				conn.Open();
				string query = $@"SELECT [Id]
								  ,[UserName]
								  ,[Email]
								  ,[Password]
								  ,[IsActive]
							  FROM [dbo].[userLoing] WHERE Email=@Email AND Password=@Password AND IsActive=@IsActive";
				SqlCommand cmd = new SqlCommand(query, conn);
				List<SqlParameter> para = new List<SqlParameter>()
				{
					new SqlParameter("@Email", userEmail),
					new SqlParameter("@Password", userPassword),
					new SqlParameter("@IsActive", true)
				};
				cmd.Parameters.AddRange(para.ToArray());
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				conn.Close();

				CanAuthenticate(userEmail, userPassword);

				if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
				{
					if (dt.Rows.Count > 0)
					{
						MessageBox.Show("Login is successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					MessageBox.Show("Login is not successful", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				}

			} 
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			lblEmailError.Visible = false;
			lblPasswordError.Visible = false;
		}

		private void CanAuthenticate(string userEmail, string userPassword)
		{
			if (string.IsNullOrEmpty(userEmail))
				lblEmailError.Visible = true;
			else
				lblEmailError.Visible = false;

			if (string.IsNullOrEmpty(userPassword))
				lblPasswordError.Visible = true;
			else
				lblPasswordError.Visible = false;
		}
	}
}
