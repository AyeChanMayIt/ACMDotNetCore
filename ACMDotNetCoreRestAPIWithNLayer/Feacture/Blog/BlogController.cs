using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _blBlog;

        public BlogController()
        {
            _blBlog = new BL_Blog();
        }

        [HttpGet("Getall")]
     //  [Route("Getall")]
        public IActionResult Read()
        {
            var lst = _blBlog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("Edit/{id}")]
       // [Route("GetByID")]
        //[ActionName("EditBlog")]
        public IActionResult Edit(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("CreateBlog")]
     //   [Route("CreateBlog")]
        public IActionResult Create(BlogModel2 blog)
        {
            var result = _blBlog.CreateBlog(blog);
            int results = Convert.ToInt32(result);
            string message = results > 0 ? "Create Success" : "Create Fail";
            return Ok(message);
        }

        [HttpPut("Update/{blogid}")]
     //   [Route("UpdateBlog")]
        public IActionResult Update(int blogid, BlogModel2 blog) // along object update data
        {
            var item = _blBlog.GetBlog(blogid);
            if (item is null)
            {
                return NotFound();
            }
            var result = _blBlog.UpdateBlog(blogid, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }
        [HttpPatch("Patch/{id}")]
        //[Route("PatchBlog")]
        public IActionResult Patch(int id, BlogModel2 blog) // one or two update data
        {

            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            var result = _blBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }
        [HttpDelete("Delete/{id}")]
        //[Route("DeleteBlog")]
        public IActionResult Delete(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            var result = _blBlog.DeleteBlog(id);
            string message = result > 0 ? "Delet Success" : "Delet Fail";
            return Ok(message);
        }

    }
}
