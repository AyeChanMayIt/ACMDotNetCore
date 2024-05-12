using ACMDotNetCore.RestApi.Db;

namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog()
        {
            _context = new AppDbContext();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item= _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return item;
        }
        public int CreateBlog(BlogModel requestmodel)
        {
            _context.Blogs.Add(requestmodel);
            var reuslt = _context.SaveChanges();   
            return reuslt;
        }
        public int UpdateBlog(int id, BlogModel requestmodel)
        {
            var item=_context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestmodel.BlogTitle;
            item.BlogAuthor=requestmodel.BlogAuthor;
            item.BlogContent=requestmodel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }
        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;
            
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
