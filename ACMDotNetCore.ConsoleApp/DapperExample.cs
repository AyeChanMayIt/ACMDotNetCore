using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run() 
        {
            // Read();
            //Edit(1);
            //Edit(5);
            //Create("Funny", "Mr.Bean", "Merry Cherist");
            //Update(2002,"Funny1", "Mr.Bean1", "Merry Cherist1");
            Delete(2002);
        }
        private void Read()
        {
           using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
           List<BlogDto> lst= db.Query<BlogDto>("select * From Tbl_Blog").ToList();
           
           foreach(BlogDto items in lst)
            {
                Console.WriteLine(items.BlogId);
                Console.WriteLine(items.BlogTitle);
                Console.WriteLine(items.BlogAuthor);
                Console.WriteLine(items.BlogContent);
                Console.WriteLine("---------------------------------------");
            }
        }
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var items = db.Query("select * From Tbl_Blog Where BlogId= @Blogid", new BlogDto { BlogId = id }).FirstOrDefault();

            if(items is null)
            {
                Console.WriteLine("Data Not Found\n");
                return;
            }
            Console.WriteLine(items.BlogId);
            Console.WriteLine(items.BlogTitle);
            Console.WriteLine(items.BlogAuthor);
            Console.WriteLine(items.BlogContent);
            Console.WriteLine("");
        }
        public void Create(string title,string  author,string content)
        {
            var item = new BlogDto()
            { 
                BlogTitle=title,
                BlogAuthor =author,
                BlogContent =content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                     VALUES
                           (@BlogTitle, 
                           @BlogAuthor,
                           @BlogContent)";

            using IDbConnection db=new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int reuslt= db.Execute(query,item);

            string message = reuslt > 0 ? "Saving Success" : "Saving Fail";
            Console.WriteLine(message);
        }
        public void Update(int id,string title, string author, string content)
        {
            var item = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle,
	                               [BlogAuthor] =@BlogAuthor,
	                               [BlogContent] =@BlogContent
                             WHERE BlogId=@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int reuslt = db.Execute(query, item);

            string message = reuslt > 0 ? "Updating Success" : "Updating Fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            var item = new BlogDto()
            {
                BlogId = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId=@BlogId";
            using IDbConnection db= new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int reuslt = db.Execute(query,item);
            string message = reuslt > 0 ? "Deleting Success" : "Deleting Fail";
            Console.WriteLine(message);
        }

    }



}

