using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.WinForms
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "ACMDotNetDB",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };


    }
}
