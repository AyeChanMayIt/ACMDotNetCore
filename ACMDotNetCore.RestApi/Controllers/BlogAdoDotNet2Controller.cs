using ACMDotNetCore.ConsoleApp.Services;
using ACMDotNetCore.RestApi.Model;
using ACMDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;




namespace ACMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "Select * From Tbl_Blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "Select * From Tbl_Blog Where BlogId = @BlogId";

            //---Way 1----- wtithout params
            //AdoDotNetParameter[] parameter=new AdoDotNetParameter[1];
            //parameter[0]= new AdoDotNetParameter("@BlogId", id);
            //var lst=_adoDotNetService.Query<BlogModel>(query,parameter);

            //---Way 2----- wtih params
            var items =_adoDotNetService.QueryFirstOrDefault<BlogModel>(query,
                     new AdoDotNetParameter("@BlogId", id) );
            if(items is null)
            {
                return NotFound("Data Not Exits");
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
             var result = _adoDotNetService.Execute(query, 
            new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
            new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
            new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Save Sucessful" : "Save Error";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog) 
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle,
	                               [BlogAuthor] =@BlogAuthor,
	                               [BlogContent] =@BlogContent
                             WHERE BlogId=@BlogId";
                var result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent));       
                string message = result > 0 ? "Update Sucessful" : "Update Error";
                return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id) 
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString); 
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //int result = cmd.ExecuteNonQuery();
            //connection.Close();
            var result = _adoDotNetService.Execute(query,
            new AdoDotNetParameter("@BlogId", id));
           string message = result > 0 ? "Delete Success" : "Can't Delete";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
             string conditions=string.Empty;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("Data cann't update.");
            }
            conditions=conditions.Substring(0,conditions.Length-2);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                              SET {conditions}
                              WHERE BlogId=@BlogId";            
            var result = _adoDotNetService.Execute(query, 
            new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
            new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
            new AdoDotNetParameter("@BlogContent", blog.BlogContent) );
            string message = result > 0 ? "Update Sucessful" : "Update Error";
            return Ok(message);
        }

        

    }
}
