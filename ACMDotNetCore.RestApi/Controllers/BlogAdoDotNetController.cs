using ACMDotNetCore.ConsoleApp.Services;
using ACMDotNetCore.RestApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using ACMDotNetCore.Shared;



namespace ACMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {   
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "Select * From Tbl_Blog";

            SqlConnection _connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            // List<BlogModel> lst=new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel
            //    {
            //        BlogId = Convert.ToInt32(dr["BlogID"]),
            //        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //        BlogContent = Convert.ToString(dr["BlogContent"]),
            //        BlogTitle = Convert.ToString(dr["BlogTitle"])

            //    };
            //    lst.Add(blog);
            //}
           
            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogID"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"])

            }).ToList();
           
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "Select * From Tbl_Blog Where BlogId = @BlogId";
            SqlConnection _connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            _connection .Open();
            SqlCommand cmd=new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            if(dt.Rows.Count == 0)
            {
                return NotFound("Data Not Exits");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogID"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"])

            };
            return Ok(item);
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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
           
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving Sucessful" : "Saving Error";
            connection.Close();
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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd=new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Update Sucessful" : "Update Error";
            connection.Close();
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id) 
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString); 
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Delete Success" : "Can't Delete";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
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
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if(blog.BlogTitle != null )
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }
            if (blog.BlogAuthor != null)
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }
            if (blog.BlogAuthor != null)
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
                      
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Update Sucessful" : "Update Error";
            connection.Close();
            return Ok(message);
        }

     

    }
}
