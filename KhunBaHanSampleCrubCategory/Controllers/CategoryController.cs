using KhunBaHanSampleCrubCategory.Models;
using KhunBaHanSampleCrubCategory.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KhunBaHanSampleCrubCategory.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration? _configuration;
        private readonly AdoDotNetServices _adoDotNetServices;

        public CategoryController(IConfiguration? configuration, AdoDotNetServices adoDotNetServices)
        {
            _configuration = configuration;
            _adoDotNetServices = adoDotNetServices;
        }

        //getCategoryDatafromDB
        public IActionResult Index()
        {
            try
            {
                string query = @"SELECT [CategoryId]
                    ,[CategoryName]
                    ,[IsActive]
                FROM [dbo].[Category] WHERE IsActive = @IsActive ORDER BY CategoryId DESC";
                SqlParameter[] getDataListPara = { new SqlParameter("IsActive", true) };
                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(query, getDataListPara);

                string jsonStr = JsonConvert.SerializeObject(dt);
                List<CategoryModel> resLst = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonStr)!;

                return View(resLst);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //CreateCategory
        public IActionResult CreateCategory()
        {
            return View();
        }

        //duplicate case
        [HttpPost]
        public IActionResult Save(CategoryRequestModel requestModel)
        {
            try 
            {
                #region duplicateCase
                string duplicateQuery = @"SELECT [CategoryId]
                    ,[CategoryName]
                    ,[IsActive]
                FROM [dbo].[Category] WHERE CategoryName = @CategoryName AND IsActive = @IsActive";
                List<SqlParameter> duplicatePara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryName", requestModel.CategoryName),
                    new SqlParameter("@IsActive", true)
                };
                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(duplicateQuery, duplicatePara.ToArray());
                if (dt.Rows.Count > 0)
                {
                    TempData["error"] = "Category Name Already Exist.";
                    return RedirectToAction("Index", "Category");
                }
                #endregion

                #region saveCategory
                string createQuery = @"INSERT INTO Category (CategoryName, IsActive) VALUES (@CategoryName, @IsActive)";
                List<SqlParameter> createPara = new List<SqlParameter>()
                    {
                        new SqlParameter("@CategoryName", requestModel.CategoryName),
                        new SqlParameter("@IsActive", true)
                    };

                int resultQuery = _adoDotNetServices.Execute(createQuery, createPara.ToArray());
                if (resultQuery > 0)
                {
                    TempData["success"] = "Creating Successfully.";
                }
                else
                {
                    TempData["error"] = "Creating Fail. Please try again!";
                }
                return RedirectToAction("Index", "Category");
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Delete(long id)
        {
            try
            {
                string query = @"UPDATE Category SET IsActive = @IsActive WHERE CategoryId = @CategoryId";
                List<SqlParameter> parameters = new()
                {
                    new SqlParameter("@IsActive", false),
                    new SqlParameter("@CategoryId", id)
                };
                int result = _adoDotNetServices.Execute(query, parameters.ToArray());

                if (result > 0)
                {
                    TempData["success"] = "Deleting Successful.";
                }
                else
                {
                    TempData["error"] = "Deleting Fail!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
