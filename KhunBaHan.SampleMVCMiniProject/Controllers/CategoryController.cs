using KhunBaHan.SampleMVCMiniProject.Models;
using KhunBaHan.SampleMVCMiniProject.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace KhunBaHan.SampleMVCMiniProject.Controllers
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

        public IActionResult GetListDataCategory()
        {
            try
            {
                //getDatafromDatabase
                string query = @"SELECT [CategoryId]
                    ,[CategoryName]
                    ,[IsActive]
                FROM [dbo].[Category] WHERE IsActive = @IsActive ORDER BY CategoryId DESC";
                SqlParameter[] para = { new SqlParameter("@IsActive", true) };
                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(query, para);
                
                string jsonStr = JsonConvert.SerializeObject(dt);
                List<GetCategoryModel> resStr = JsonConvert.DeserializeObject<List<GetCategoryModel>>(jsonStr)!;

                return View(resStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult CreateCategoryForm() { 
            try
            {
                return View();
                
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveCategoryForm(RequestCategoryModel requestCategoryModel)
        {
            try
            {
                #region CheckDuplicate Case
                string checkDuplicateQuery = @"SELECT [CategoryId]
                    ,[CategoryName]
                    ,[IsActive]
                FROM [dbo].[Category] WHERE CategoryName = @CategoryName AND IsActive = @IsActive";
                List<SqlParameter> checkDuplicatePara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryName", requestCategoryModel.CategoryName),
                    new SqlParameter("@IsActive", true)
                };

                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(checkDuplicateQuery, checkDuplicatePara.ToArray());
                if(dt.Rows.Count > 0)
                {
                    TempData["error"] = "Your put Category Name is Already Exist.";
                    return RedirectToAction("GetListDataCategory", "Category");
                }
                #endregion

                #region SaveNewCategory
                string saveNewCategoryQuery = @"INSERT INTO Category (CategoryName, IsActive) VALUES (@CategoryName, @IsActive)";
                List<SqlParameter> saveNewCategoryPara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryName", requestCategoryModel.CategoryName),
                    new SqlParameter("@IsActive", true)
                };
                int saveNewCategory = _adoDotNetServices.Execute(saveNewCategoryQuery, saveNewCategoryPara.ToArray());
                if(saveNewCategory > 0)
                {
                    TempData["success"] = "Your creating category name is successfully.";
                } else
                {
                    TempData["error"] = "Your creating category name is fail!";
                }
                return RedirectToAction("GetListDataCategory", "Category");
                #endregion

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Edit(long id) 
        {
            try
            {
                string editQuery = @"SELECT [CategoryId]
                      ,[CategoryName]
                      ,[IsActive]
                  FROM [dbo].[Category] WHERE CategoryId = @CategoryId AND IsActive = @IsActive";
                List<SqlParameter> editPara = new List<SqlParameter>
                {
                    new SqlParameter("@CategoryId", id),
                    new SqlParameter("@IsActive", true)
                };

                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(editQuery, editPara.ToArray());
                List<GetCategoryModel> lst = new();
                if (dt.Rows.Count > 0)
                {
                    string jsonStr = JsonConvert.SerializeObject(dt);
                    lst = JsonConvert.DeserializeObject<List<GetCategoryModel>>(jsonStr)!;
                }

                return View(lst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }     
        }

        [HttpPost]
        public IActionResult Update(GetCategoryModel dataModel)
        {
            try
            {
                #region duplicateCategoryName
                string duplicateCategoryNameQuery = @"SELECT [CategoryId]
                    ,[CategoryName]
                    ,[IsActive]
                FROM [dbo].[Category] WHERE CategoryName = @CategoryName AND IsActive = @IsActive";
                List<SqlParameter> duplicateCategoryNamePara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryName", dataModel.CategoryName),
                    new SqlParameter("@IsActive", true)
                };

                DataTable dt = _adoDotNetServices.QueryFirstOrDefault(duplicateCategoryNameQuery, duplicateCategoryNamePara.ToArray());
                if(dt.Rows.Count > 0)
                {
                    TempData["error"] = "Categroy Name is Already Exist.";
                    return RedirectToAction("GetListDataCategory", "Category");
                }

                #endregion

                #region UpdateSuccessfully
                string query = @"UPDATE Category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                List<SqlParameter> parameters = new()
                {
                    new SqlParameter("@CategoryName", dataModel.CategoryName),
                    new SqlParameter("@CategoryId", dataModel.CategoryId)
                };
                int result = _adoDotNetServices.Execute(query, parameters.ToArray());

                if (result > 0)
                {
                    TempData["success"] = "Updating Successful.";
                }
                else
                {
                    TempData["error"] = "Updating Fail!";
                }
                return RedirectToAction("GetListDataCategory", "Category");
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
                string deleteQuery = "UPDATE Category SET IsActive = @IsActive WHERE CategoryId = @CategoryId";
                List<SqlParameter> deletePara = new List<SqlParameter>()
                {
                    new SqlParameter("@CategoryId", id),
                    new SqlParameter("@IsActive", false)
                };
                int deleteResult = _adoDotNetServices.Execute(deleteQuery, deletePara.ToArray());

                if (deleteResult > 0)
                {
                    TempData["success"] = "Deleting Successfully.";                
                }
                else 
                {
                    TempData["error"] = "Deleting Fail.";
                }
                return RedirectToAction("GetListDataCategory", "Category");
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
