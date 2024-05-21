using ACMDotNetCore.RestApi.Model;
using ACMDotNetCore.Shared;
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
        public FrmBlog()
        {
            InitializeComponent();
            DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog=new BlogModel();
                blog.BlogTitle= txttitle.Text;
                blog.BlogAuthor= txtauthor.Text;
                blog.BlogContent= txtcontent.Text;
                //_dapperService.Execute();

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            txttitle.Clear();
            txtcontent.Clear();
            txtauthor.Clear();

            txttitle.Focus();
        }
    }
}
