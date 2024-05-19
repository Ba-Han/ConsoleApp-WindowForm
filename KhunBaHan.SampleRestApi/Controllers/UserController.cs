using KhunBaHan.SampleRestApi.Models;
using KhunBaHan.SampleRestApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace KhunBaHan.SampleRestApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AdoDotNetServices _adoDotNetServices;

        public UserController(IConfiguration configuration, AdoDotNetServices adoDotNetServices)
        {
            _configuration = configuration;
            _adoDotNetServices = adoDotNetServices;
        }

        [HttpPost]
        [Route("api/account/login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            string query = @"SELECT [Id]
                  ,[UserName]
                  ,[Email]
                  ,[Password]
                  ,[IsActive]
              FROM [dbo].[userLoing] WHERE Email = @Email AND Password = @Password AND IsActive = @IsActive";
            List<SqlParameter> para = new List<SqlParameter>()
           {
               new SqlParameter("@Email", loginRequest.Email),
               new SqlParameter("@Password", loginRequest.Password),
               new SqlParameter("@IsActive", true)
           };

            DataTable dt = _adoDotNetServices.QueryFirstOrDefatul(query, para.ToArray());
            string message = dt.Rows.Count > 0 ? "Login Successful." : "Login Fail.";

            return Ok(message);
        }
    }
}
