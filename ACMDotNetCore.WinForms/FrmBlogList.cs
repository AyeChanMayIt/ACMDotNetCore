using ACMDotNetCore.Shared;
using ACMDotNetCore.WinForms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACMDotNetCore.WinForms
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * from Tbl_Blog");
            dgvData.DataSource = lst;
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * from Tbl_Blog");
            dgvData.DataSource = lst;
        }
        
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colID"].Value);
            #region IfCase
            //if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            //{
            //    FrmBlog frm= new FrmBlog(blogId);
            //    frm.ShowDialog();
            //    BlogList();
            //}
            //else if(e.ColumnIndex == (int)EnumFormControlType.Delete)
            //{
            //    var dialogReuslt = MessageBox.Show("Are u sure delete","",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            //    if (dialogReuslt != DialogResult.Yes) return;               
            //    DeleteBlog(blogId);
            //}
            #endregion

            #region Switch Case
            int index=e.ColumnIndex;
            EnumFormControlType enumFormControlType = (EnumFormControlType)index;
            switch(enumFormControlType)
            {
                case EnumFormControlType.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();

                    BlogList();
                    break;
                case EnumFormControlType.Delete:
                    var dialogReuslt = MessageBox.Show("Are u sure delete", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogReuslt != DialogResult.Yes) return;

                    DeleteBlog(blogId);
                    break;
                case EnumFormControlType.None:
                    break;
                default:
                    MessageBox.Show("Invalid Case");
                    break;
            }
            #endregion

        }
        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId=@BlogId";
            int result = _dapperService.Execut(query,new { BlogId = id });
            string message = result > 0 ? "Sucessfule Delete" : "Can't Delete";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
