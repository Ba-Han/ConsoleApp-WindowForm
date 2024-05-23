using KhunBaHan.EFCoreSample.Models;
using KhunBaHan.EFCoreSample.Models.CategoryRequestModel;
using KhunBaHan.EFCoreSample.Models.CategoryResponseModel;
using KhunBaHan.EFCoreSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KhunBaHan.EFCoreSample.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var dataLst = await _appDbContext.Tbl_Category
                    .AsNoTracking()
                    .OrderByDescending(x => x.CategoryId)
                    .Where(x => (bool)x.IsActive!)
                    .ToListAsync();
                var lst = dataLst.Select(x => new CategoryModel()
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    IsActive = x.IsActive
                }).ToList();

                var respModel = new CategoryResponseListModel()
                {
                    CategoriesResponseList = lst
                };
                return Ok(respModel);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.CategoryName) || requestModel.CategoryName == "string")
                    return BadRequest("Category Name cannot be empty.");

                bool isDuplicate = await _appDbContext.Tbl_Category
                    .AsNoTracking()
                    .AnyAsync(x => x.CategoryName == requestModel.CategoryName && x.IsActive);
                if (isDuplicate)
                    return Conflict("Category name is already exist.");

                await _appDbContext.Tbl_Category.AddAsync(requestModel.Change());
                int result = await _appDbContext.SaveChangesAsync();

                return result > 0 ? StatusCode (200, "Create Category is Successful") : BadRequest("Creating Fail");

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryRequestModel requestModel, long id)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.CategoryName))
                    return BadRequest("Category Name cannot be empty.");

                bool isDuplicate = await _appDbContext.Tbl_Category
                    .AsNoTracking()
                    .AnyAsync(x => x.CategoryName == requestModel.CategoryName && x.IsActive && x.CategoryId != id);
                if (isDuplicate)
                    return Conflict("Category name is already exist.");

                var item = await _appDbContext.Tbl_Category
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CategoryId == id && x.IsActive);
                if (item is null)
                    return NotFound("Category Not Found.");
                item.CategoryName = requestModel.CategoryName;
                _appDbContext.Entry(item).State = EntityState.Modified;

                int result = await _appDbContext.SaveChangesAsync();
                return result > 0 ? StatusCode(200, "Update Category is Successful") : BadRequest("Updating Fail");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var item = await _appDbContext.Tbl_Category
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CategoryId == id && x.IsActive);
                if(item is null)
                    return NotFound("Category Not Found.");

                item.IsActive = false;
                _appDbContext.Entry(item).State = EntityState.Modified;

                int result = await _appDbContext.SaveChangesAsync();
                return result > 0 ? StatusCode(200, "Delete Category is Successful") : BadRequest("Deleting Fail");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
