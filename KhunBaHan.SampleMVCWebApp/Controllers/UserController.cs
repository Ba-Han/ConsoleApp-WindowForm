using KhunBaHan.SampleMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KhunBaHan.SampleMVCWebApp.Controllers
{
	public class UserController : Controller
	{
		private readonly IConfiguration _configuration;

		public UserController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public IActionResult RegisterPage()
		{
			return View();
		}
		public IActionResult LoginPage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginRequestModel requestModel) 
		{
			try
			{
				SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
				conn.Open();
				string query = @"SELECT [Id]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[IsActive]
  FROM [dbo].[userLogin] WHERE Email = @Email AND Password = @Password AND IsActive = @IsActive";
				List<SqlParameter> parameters = new List<SqlParameter>()
				{
					new SqlParameter("@Email", requestModel.Email),
					new SqlParameter("@Password", requestModel.Password),
					new SqlParameter("@IsActive", true)
				};
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddRange(parameters.ToArray());
				SqlDataAdapter adatper = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				adatper.Fill(dt);
				conn.Close();

				if (dt.Rows.Count > 0)
				{
					return RedirectToAction("Index", "Home");
				}

				TempData["error"] = "Login Fail!, Your email or password are wroong. Please try again!";
				return RedirectToAction("LoginPage", "User");
			}
			catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
	}
}
