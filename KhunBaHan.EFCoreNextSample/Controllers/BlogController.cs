using KhunBaHan.EFCoreNextSample.Models.BlogRequestModel;
using KhunBaHan.EFCoreNextSample.Models.BlogResponeListModel;
using KhunBaHan.EFCoreNextSample.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhunBaHan.EFCoreNextSample.Controllers
{

    [Route("api/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AddDbContext _addDbContext;

        public BlogController(AddDbContext addDbContext)
        {
            _addDbContext = addDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var dataList = await _addDbContext.Tbl_BlogModels
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

                var responseBlogData = new BlogResponeListModel()
                {
                    BlogResponseListData = lst
                };

                return Ok(responseBlogData);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.BlogTitle) || string.IsNullOrEmpty(requestModel.BlogAuthor) || string.IsNullOrEmpty(requestModel.BlogContent)
                  || requestModel.BlogTitle == "string" || requestModel.BlogAuthor == "string" || requestModel.BlogContent == "string")
                    return BadRequest("Blog Fields can not be empty.");

                var isDuplicate = await _addDbContext.Tbl_BlogModels
                    .AsNoTracking()
                    .AnyAsync(x => x.BlogTitle == requestModel.BlogTitle);
                if (isDuplicate)
                    return Conflict("Blog Title is already exist.");

                var item = await _addDbContext.AddAsync(requestModel.Change());
                int result = await _addDbContext.SaveChangesAsync();

                return result > 0 ? StatusCode(200, "Created Blog are successfuly") : BadRequest("Creating Blog fail.");

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("id")]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel requestModel, long id)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.BlogTitle) || string.IsNullOrEmpty(requestModel.BlogAuthor) || string.IsNullOrEmpty(requestModel.BlogContent)
                  || requestModel.BlogTitle == "string" || requestModel.BlogAuthor == "string" || requestModel.BlogContent == "string")
                    return BadRequest("Blog Fields can not be empty.");

                var isDuplicate = await _addDbContext.Tbl_BlogModels
                    .AsNoTracking()
                    .AnyAsync(x => x.BlogTitle == requestModel.BlogTitle && x.BlogId != id);
                if (isDuplicate)
                    return Conflict("Blog Title is already exist.");

                var item = await _addDbContext.Tbl_BlogModels
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                    return NotFound("Blog Data Not Found.");

                item.BlogTitle = requestModel.BlogTitle;
                item.BlogAuthor = requestModel.BlogAuthor;
                item.BlogContent = requestModel.BlogContent;
                _addDbContext.Entry(item).State = EntityState.Modified;

                int result = await _addDbContext.SaveChangesAsync();
                return result > 0 ? StatusCode(200, "Updated Blog are successfuly") : BadRequest("Updating Blog fail.");

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBlog(long id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var item = await _addDbContext.Tbl_BlogModels
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                    return NotFound("Blog Data not found.");

                _addDbContext.Tbl_BlogModels.Remove(item);
                int result = await _addDbContext.SaveChangesAsync();

                return result > 0 ? StatusCode(200, "Deleted Blog data is successfully.") : BadRequest("Deleting fail.");

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
