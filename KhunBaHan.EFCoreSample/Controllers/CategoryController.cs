using KhunBaHan.EFCoreSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreSample.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var dataLst = await _appDbContext.Category
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

                var respModel = new CategoryResponseModel()
                {
                    CategoriesResponse = lst
                };
                return Ok(respModel);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
