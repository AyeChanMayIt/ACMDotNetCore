using ACMDotNetCore.ConsoleApp.Services;
using ACMDotNetCore.RestApi.Db;
using ACMDotNetCore.RestApi.Model;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ACMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLogDrapperController : ControllerBase
    {
       //Read
        [HttpGet]
        public IActionResult GetBlogs() 
        {
            string query = "select * From Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString); 
            List<BlogModel> list= db.Query<BlogModel>(query).ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * From Tbl_Blog Where BlogId= @Blogid";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var items=db.Query<BlogModel>(query,new BlogModel { BlogId = id}).FirstOrDefault();
            if (items is null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(items);
        }
        [HttpPost]
        public IActionResult CreateBlog()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id)
        {
            return Ok();
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            return Ok();
        }
        

    }
}
