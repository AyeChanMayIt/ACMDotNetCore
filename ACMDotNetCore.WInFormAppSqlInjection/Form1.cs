using ACMDotNetCore.Shared;
using ACMDotNetCore.WinForms;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ACMDotNetCore.WInFormAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string query = $"Select * From Tbl_User Where email=@Email and password=@Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtemail.Text.Trim(),
                Password = txtpass.Text.Trim()
            });
            if (model is null)
            {
                MessageBox.Show("User doesn't exit");
                return;
            }
            MessageBox.Show("Is Amdin : " + model.Email);
        }      
    }
    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}