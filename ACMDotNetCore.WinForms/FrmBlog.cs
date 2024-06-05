using ACMDotNetCore.Shared;
using ACMDotNetCore.WinForms.Model;
using ACMDotNetCore.WinForms.Queries;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACMDotNetCore.WinForms
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int BlogId;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public FrmBlog(int blogId)
        {
            InitializeComponent();
            BlogId = blogId;
            _dapperService = new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * From Tbl_Blog Where BlogId= @Blogid", new { BlogId = blogId });
            txttitle.Text = model.BlogTitle;
            txtauthor.Text = model.BlogAuthor;
            txtcontent.Text = model.BlogContent;

            btnsave.Visible = false;
            btnupdate.Visible = true;

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txttitle.Text.Trim();
                blog.BlogAuthor = txtauthor.Text.Trim();
                blog.BlogContent = txtcontent.Text.Trim();

                int result = _dapperService.Execut(BlogQuery.BlogCreate, blog);
                string message = result > 0 ? "Succuess Create" : "Create Fail";
                var messaageicon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messaageicon);
                if (result > 0)
                {
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            ClearControl();
            
        }

        private void ClearControl()
        {
            txttitle.Clear();
            txtcontent.Clear();
            txtauthor.Clear();
            txttitle.Focus();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogId = BlogId,
                    BlogTitle = txttitle.Text.Trim(),
                    BlogAuthor = txtauthor.Text.Trim(),
                    BlogContent = txtcontent.Text.Trim()
                };
                string query = @"UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle,
	                               [BlogAuthor] =@BlogAuthor,
	                               [BlogContent] =@BlogContent
                             WHERE BlogId=@BlogId";

                int result = _dapperService.Execut(query, item);
                string message = result > 0 ? "Succuess Update" : "Update Fail";
                var messaageicon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messaageicon);
                if (result > 0)
                {
                    ClearControl();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
