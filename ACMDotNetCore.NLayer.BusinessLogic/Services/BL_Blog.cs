using ACMDotNetCore.NLayer.DataAccess.Model;
using ACMDotNetCore.NLayer.DataAccess.Services;

namespace ACMDotNetCore.NLayer.BusinessLogic.Services
{
    public class BL_Blog
    {
        private readonly DA_Blog _dablog;

        public BL_Blog()
        {
            _dablog = new DA_Blog();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _dablog.GetBlogs();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item = _dablog.GetBlog(id);
            return item;
        }
        public int CreateBlog(BlogModel reqestmodel)
        {
            var item = _dablog.CreateBlog(reqestmodel);
            return item;
        }
        public int UpdateBlog(int id, BlogModel reqestmodel)
        {
            var item = _dablog.UpdateBlog(id, reqestmodel);
            return item;
        }
        public int DeleteBlog(int id)
        {
            var item = _dablog.DeleteBlog(id);
            return item;
        }
    }
}
