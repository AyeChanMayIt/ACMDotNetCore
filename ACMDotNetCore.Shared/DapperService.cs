using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace ACMDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionstring;

        public DapperService(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<M> Query<M>(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionstring);
            var list = db.Query<M>(query,param).ToList();
            return list;
        }
        public M QueryFirstOrDefault<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionstring);
            var items = db.Query<M>(query, param).FirstOrDefault();
            return items;
        }

        public int Execut(string sql,object? param=null)
        {
            using IDbConnection db = new SqlConnection(_connectionstring);
            var result= db.Execute(sql, param);
            return result;
        }

        
    }
}
