using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.ConsoleApp
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        { 
            DataSource=".",
            InitialCatalog = "ACMDotNetDB",
            UserID="sa",
            Password= "aya123",
            TrustServerCertificate=true
        };


    }
}
