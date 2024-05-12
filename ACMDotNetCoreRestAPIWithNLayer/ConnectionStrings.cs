using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.RestAPIWithNLayer
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "ACMDotNetDB",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };


    }
}
