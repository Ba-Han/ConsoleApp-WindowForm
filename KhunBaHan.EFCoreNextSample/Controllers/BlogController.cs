using KhunBaHan.EFCoreNextSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreNextSample.Controllers
{
    public class BlogController : ControllerBase
    {
        private readonly AddDbContext _addDbContext;

        public BlogController(AddDbContext addDbContext)
        {
            _addDbContext = addDbContext;
        }

        [HttpGet]
        [Route("api/blogs")]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var dataList = await _addDbContext.Blog
                    .AsNoTracking()
                    .OrderByDescending(x => x.BlogId)
                    .ToListAsync();
                var lst = dataList.Select(x => new BlogModel()
                {
                    BlogId = x.BlogId,
                    BlogTitle = x.BlogTitle,
                    BlogAuthor = x.BlogAuthor,
                    BlogContent = x.BlogContent
                }).ToList();

                var responseBlogData = new BlogResponseModel()
                {
                    BlogResponseData = lst
                };

                return Ok(responseBlogData);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
