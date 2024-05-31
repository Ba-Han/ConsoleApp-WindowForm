using KhunBaHan.SaveDBMVCExpense.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KhunBaHan.SaveDBMVCExpense.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IConfiguration _configuration;

        public ExpenseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Expense()
        {
            try
            {
                //Get Expense from DB
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                conn.Open();
                string query = @"SELECT [Id]
                    ,[Value]
                    ,[Description]
                FROM [dbo].[Expense] ORDER BY Id ASC";
                //SqlParameter[] para = { new SqlParameter() };
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddRange(para);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                string jsonStr = JsonConvert.SerializeObject(dt);
                List<GetExpense> expenseLst = JsonConvert.DeserializeObject<List<GetExpense>>(jsonStr)!;
                return View(expenseLst);
                //end
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult CreateOrEditExpense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEditExpenseForm(Expense requestExpense)
        {
            try
            {
                //Create Case
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                conn.Open();
                string query = @"INSERT INTO Expense(Value,Description) VALUES(@Value,@Description)";
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Value", requestExpense.Value),
                    new SqlParameter("@Description", requestExpense.Description)
                };
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters.ToArray());
                int resExecute = cmd.ExecuteNonQuery();
                conn.Close();

                if (resExecute > 0)
                {
                    TempData["success"] = "Creating is successful.";
                }
                return RedirectToAction("Expense");
                //End

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Edit(int? id)
        {
            try
            {
                //GET Values first into edit form before save
                SqlConnection conn = new SqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
                conn.Open();
                string editQuery = @"SELECT [Id]
                      ,[Value]
                      ,[Description]
                  FROM [dbo].[Expense] WHERE Id = @Id";
                List<SqlParameter> editPara = new List<SqlParameter>
                {
                    new SqlParameter("@Id", id)
                };
                SqlCommand cmd = new SqlCommand(editQuery, conn);
                cmd.Parameters.AddRange(editPara.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                List<GetExpense> lst = new();
                if (dt.Rows.Count > 0)
                {
                    string jsonStr = JsonConvert.SerializeObject(dt);
                    lst = JsonConvert.DeserializeObject<List<GetExpense>>(jsonStr)!;
                }
                return View(lst);
                //end
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateExpense(GetExpense getExpense)
        {
            try
            {
                //Check Duplicate Expense
                SqlConnection checkConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                checkConn.Open();
                string checkDuplicateQuery = @"SELECT [Id]
                      ,[Value]
                      ,[Description]
                  FROM [dbo].[Expense] WHERE Value = @Value AND Description = @Description";
                List<SqlParameter> checkDuplicatePara = new List<SqlParameter>()
                {
                    new SqlParameter("@Value", getExpense.Value),
                    new SqlParameter("@Description", getExpense.Description)
                };
                SqlCommand checkDuplicateCMD = new SqlCommand(checkDuplicateQuery, checkConn);
                checkDuplicateCMD.Parameters.AddRange(checkDuplicatePara.ToArray());
                SqlDataAdapter adapter = new SqlDataAdapter(checkDuplicateCMD);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                checkConn.Close();

                if (dt.Rows.Count > 0)
                {
                    TempData["error"] = "Expense Fields are Already Exist.";
                    return RedirectToAction("Expense");
                }
                //End

                //Update Edit Expenese
                SqlConnection saveConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                saveConn.Open();
                string saveQuery = @"UPDATE Expense SET Value = @Value, Description = @Description WHERE Id = @Id";
                List<SqlParameter> savePara = new()
                {
                    new SqlParameter("@Value", getExpense.Value),
                    new SqlParameter("@Description", getExpense.Description),
                    new SqlParameter("@Id", getExpense.Id)
                };
                SqlCommand saveCMD = new SqlCommand(saveQuery, saveConn);
                saveCMD.Parameters.AddRange(savePara.ToArray());
                int resSaveExecute = saveCMD.ExecuteNonQuery();
                saveConn.Close();

                if (resSaveExecute > 0)
                {
                    TempData["success"] = "Updating Successful.";
                }
                else
                {
                    TempData["error"] = "Updating Fail!";
                }
                return RedirectToAction("Expense");
                //End
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                SqlConnection deleteConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                deleteConn.Open();
                string deleteQuery = "DELETE FROM Expense WHERE Id = @Id";
                List<SqlParameter> deletePara = new List<SqlParameter>()
                {
                    new SqlParameter("@Id", id)
                };
                SqlCommand deleteCMD = new SqlCommand(deleteQuery, deleteConn);
                deleteCMD.Parameters.AddRange(deletePara.ToArray());
                int deleteResult = deleteCMD.ExecuteNonQuery();
                deleteConn.Close();

                if (deleteResult > 0)
                {
                    TempData["success"] = "Deleting Successfully.";
                }
                else
                {
                    TempData["error"] = "Deleting Fail.";
                }
                return RedirectToAction("Expense");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
