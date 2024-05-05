using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq.Expressions;


namespace ACMDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionstring;
        public AdoDotNetService(string connectionstring)
        {
            _connectionstring = connectionstring;
        }     

        public List<T> Query<T>(string query,params AdoDotNetParameter[]?parameters)
        {   
            SqlConnection _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            if(parameters is not null && parameters.Length > 0 )
            {
                //---Way 1-----
                //foreach (var items in parameters)
                //{
                //    cmd.Parameters.AddWithValue(items.Name, items.Value);
                //}

                //---Way 2-----
                //var parameterArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                //cmd.Parameters.AddRange(parameterArray);

                //---Way 3-----
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name,item.Value)).ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            string json=JsonConvert.SerializeObject(dt); // C# to Json
            List<T> result = JsonConvert.DeserializeObject<List<T>>(json)!; // Json to C#
            return result;
        }
        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            _connection.Close();

            string json = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> result = JsonConvert.DeserializeObject<List<T>>(json)!; // Json to C#
            return result[0];
        }
        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
             var result = cmd.ExecuteNonQuery();
            _connection.Close();
             return result;
        }

        public int ExecutePatch(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection _connection = new SqlConnection(_connectionstring);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result;
        }


    }

    public class AdoDotNetParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

}
