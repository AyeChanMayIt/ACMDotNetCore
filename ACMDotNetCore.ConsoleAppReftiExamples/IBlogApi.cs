using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleAppReftiExamples
{
    public interface IBlogApi
    {
        [Get("/api/Blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<BlogModel> GetBlogs(int id);

        [Post("/api/Blog")]
        Task<string> CreateBlogs(BlogModel blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlogs(int id,BlogModel blog);

        [Delete("/api/Blog/{id}")]
        Task<string> DeleteBlogs(int id);
    }
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
