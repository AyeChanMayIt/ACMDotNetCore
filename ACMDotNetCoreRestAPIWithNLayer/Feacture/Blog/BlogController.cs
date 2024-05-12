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
    
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _blBlog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _blBlog.CreateBlog(blog);
            int results=Convert.ToInt32(result);
            string message = results > 0 ? "Create Success" : "Create Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog) // along object update data
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            var result=_blBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog) // one or two update data
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
            var result=_blBlog.UpdateBlog(id,blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound();
            }
            var result=_blBlog.DeleteBlog(id);
            string message = result > 0 ? "Delet Success" : "Delet Fail";
            return Ok(message);
        }

    }
}
