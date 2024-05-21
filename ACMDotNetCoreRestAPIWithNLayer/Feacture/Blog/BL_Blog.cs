namespace ACMDotNetCore.RestAPIWithNLayer.Feacture.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dablog;

        public BL_Blog()
        {
            _dablog = new DA_Blog();
        }
        public List<BlogModel2> GetBlogs()
        {
            var lst=_dablog.GetBlogs();
            return lst;
        }
        public BlogModel2 GetBlog(int id)
        {
            var item = _dablog.GetBlog(id);
            return item;
        }
        public int CreateBlog(BlogModel2 reqestmodel)
        {
            var item = _dablog.CreateBlog(reqestmodel);
            return item;
        }
        public int UpdateBlog(int id, BlogModel2 reqestmodel)
        {
            var item=_dablog.UpdateBlog(id, reqestmodel);
            return item;
        }

        //public int UpdateBlogs(int id, BlogModel reqestmodel)
        //{
        //    var item = "";
        //    if(reqestmodel.BlogTitle != null)
        //    {
        //       item = reqestmodel.BlogTitle;
        //    }
        //    if (reqestmodel.BlogAuthor != null)
        //    {
        //        item = reqestmodel.BlogAuthor;
        //    }
        //    if (reqestmodel.BlogContent != null)
        //    {
        //        item = reqestmodel.BlogContent;
        //    }

        //     var items = _dablog.UpdateBlog(id, item);
        //    return items;
        //}

        public int DeleteBlog(int id)
        {
            var item=_dablog.DeleteBlog(id); 
            return item;
        }
    }
}
