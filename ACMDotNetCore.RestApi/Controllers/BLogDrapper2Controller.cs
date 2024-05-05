using ACMDotNetCore.ConsoleApp.Services;
using ACMDotNetCore.RestApi.Db;
using ACMDotNetCore.RestApi.Model;
using ACMDotNetCore.Shared;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace ACMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLogDrapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperservice=new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

       //Read
        [HttpGet]
        public IActionResult GetBlogs() 
        {
            string query = "select * From Tbl_Blog";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //List<BlogModel> list = db.Query<BlogModel>(query).ToList();

            var list=_dapperservice.Query<BlogModel>(query);
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
           var items = FindByID(id);
            if (items is null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(items);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                     VALUES
                           (@BlogTitle, 
                           @BlogAuthor,
                           @BlogContent)";

            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //int reuslt = db.Execute(query, blog);
            int result=_dapperservice.Execut(query);

            string message = result > 0 ? "Saving Success" : "Saving Fail";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            var item = FindByID(id);
            if(item is null )
            {
                return NotFound("Data Not Found");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle,
	                               [BlogAuthor] =@BlogAuthor,
	                               [BlogContent] =@BlogContent
                             WHERE BlogId=@BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //int reuslt = db.Execute(query, blog);
            int result = _dapperservice.Execut(query,blog);
            string message = result > 0 ? "Updating Success" : "Updating Fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            var item = FindByID(id);
            if(item is null)
            {
                return NotFound("Data not found");
            }

            string conditions=string.Empty;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] =@BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] =@BlogContent, ";
            }
            if(conditions.Length == 0) 
            {
                return NotFound("Data not to update.");
            }
            conditions = conditions.Substring(0,conditions.Length - 2);
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                             SET {conditions}
                             WHERE BlogId=@BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //int reuslt = db.Execute(query, blog);
            int result = _dapperservice.Execut(query,blog);
            string message = result > 0 ? "Updating Success" : "Updating Fail";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id,BlogModel blog)
        {
            var item= FindByID(id);
            if(item is null )
            {
                return NotFound("Data Not Found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //int reuslt = db.Execute(query, blog);
            int result = _dapperservice.Execut(query, blog);
            string message = result > 0 ? "Deleting Success" : "Deleting Fail";
            return Ok(message);
        }
        
        private BlogModel? FindByID(int id)
        {
            string query = "select * From Tbl_Blog Where BlogId= @Blogid";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var items = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            var items=_dapperservice.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return items;
        }
    }
}
