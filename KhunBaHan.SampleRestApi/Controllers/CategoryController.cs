using KhunBaHan.SampleRestApi.Models;
using KhunBaHan.SampleRestApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KhunBaHan.SampleRestApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AdoDotNetServices _adoDotNetServices;

        public CategoryController(IConfiguration configuration, AdoDotNetServices adoDotNetServices)
        {
            _configuration = configuration;
            _adoDotNetServices = adoDotNetServices;
        }

        [HttpGet]
        [Route("api/categorires")]
        public IActionResult GetCategorie()
        {
            try
            {
                string query = @"SELECT [CategoryId]
                      ,[CategoryName]
                      ,[IsActive]
                  FROM [dbo].[Category]";
                SqlParameter[] para = { new("@IsActive", true) };
                SqlConnection conn = new SqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                string jsonStr = JsonConvert.SerializeObject(dt);
                var datalist = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonStr)!;

                return Ok(new CategoryResponseModel()
                {
                    DataResponseList = datalist
                });
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/createCategory")]
        public IActionResult CreateCategory([FromBody] CategoryModel categoryModel)
        {
            try
            {
                string createQuery = @"INSERT INTO Category (CategoryName, IsActive) VALUES (@CategoryName, @IsActive)";
                List<SqlParameter> createPara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryName", categoryModel.CategoryName),
                    new SqlParameter("@IsActive", true)
                };
                int resQuery = _adoDotNetServices.Execute(createQuery, createPara.ToArray());
                string getResQuery = resQuery > 0 ? "Creating Successful" : "Creating Fail";

                return Ok(getResQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
