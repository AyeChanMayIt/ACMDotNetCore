using ACMDotNetCore.MinimalAPI.Db;
using ACMDotNetCore.MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ACMDotNetCore.MinimalAPI.Feacture.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlgs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync(); //AsNoTracking is like the With NoLock on Sql
                return Results.Ok(lst);
            });

            app.MapGet("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                int result = await db.SaveChangesAsync();
                string message = result > 0 ? "Create Success" : "Create Fail";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound();
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                int result = await db.SaveChangesAsync();
                string message = result > 0 ? "Update Success" : "Update Fail";
                return Results.Ok(message);
            });

            app.MapPatch("api/Blog", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound();
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
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Update Success" : "Update Fail";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blog", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound();
                }
                int result = await db.SaveChangesAsync();
                string message = result > 0 ? "Delete Success" : "Delete Fail";
                return Results.Ok(message);
            });
            return app;
        }
    }
}
