using ACMDotNetCore.ConsoleApp.Dto;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCore_Example
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(2);
            //Edit(6);
            // Create("Funny", "Mr.Bean", "Merry Cherist");
            //Update(3003, "Funny1", "Mr.Bean1", "Merry Cherist1");
            Delete(3002);
            Delete(3003);
        }
        private void Read()
        {

            var lst = db.Blogs.ToList();
            foreach (BlogDto items in lst)
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
            var items = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (items is null)
            {
                Console.WriteLine("Data is not found");
                return;
            }
            Console.WriteLine(items.BlogId);
            Console.WriteLine(items.BlogTitle);
            Console.WriteLine(items.BlogAuthor);
            Console.WriteLine(items.BlogContent);
            Console.WriteLine("");
        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Successful Save" : " Save Fail";
            Console.WriteLine(message);

        }
        private void Update(int id, string title, string author, string content)
        {
            var items = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (items is null)
            {
                Console.WriteLine("Data is not found");
                return;
            }
            items.BlogTitle = title;
            items.BlogAuthor = author;
            items.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Successful Update" : " Update Fail";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var items = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (items is null)
            {
                Console.WriteLine("Data is not found");
                return;
            }
            db.Blogs.Remove(items);
            int result = db.SaveChanges();
            string message = result > 0 ? "Successful Delete" : " Delete Fail";
            Console.WriteLine(message);
        }
    }
}
