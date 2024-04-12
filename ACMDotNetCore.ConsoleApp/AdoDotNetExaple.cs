using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleApp
{
    internal class AdoDotNetExaple
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder=new SqlConnectionStringBuilder()
        {
            DataSource = ".", //server name
            InitialCatalog = "ACMDotNetDB",
            UserID = "sa",
            Password = "aya123"      
        };
        public void Read()
        {
            /*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "RV-IT-LP-130"; //server name
            stringBuilder.InitialCatalog = "ACMDotNetDB";
            stringBuilder.UserID = "sa";
            stringBuilder.Password = "aya123";*/
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection is open");

            string query = "select * From Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);  // for running query 
            DataTable dt = new DataTable(); //create result table
            sqlDataAdapter.Fill(dt); //accept result table

            connection.Close();
            Console.WriteLine("Connection is close");

            //dataset > datatable > data row > data col:
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog ID =>" + dr["BlogId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("----------------------------");
            }

        }
        public void Create(string title,string author,string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                     VALUES
                           (@BlogTitle, 
                           @BlogAuthor,
                           @BlogContent)";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Saving Sucessful" : "Saving Error";
            Console.WriteLine(message);     
            connection.Close();
        }
        public void Update(int id,string title,string author,string content) 
        {
            SqlConnection connection=new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle,
	                               [BlogAuthor] =@BlogAuthor,
	                               [BlogContent] =@BlogContent
                             WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Update Sucessful" : "Update Error";
            Console.WriteLine(message);
            connection.Close();
        }
    }
}
