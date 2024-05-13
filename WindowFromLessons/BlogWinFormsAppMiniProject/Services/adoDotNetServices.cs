using BlogWinFormsAppMiniProject.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogWinFormsAppMiniProject.Services
{
	public class AdoDotNetServices {
		//query
		public List<T> Query<T>(string query, SqlParameter[] sqlParameters = null!) {
			SqlConnection conn = new SqlConnection(DataBaseConnectionString._connStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(sqlParameters);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			conn.Close();

			string jsonStr = JsonConvert.SerializeObject(dt);
			List<T> resultStr = JsonConvert.DeserializeObject<List<T>>(jsonStr)!;

			return resultStr;
		}
		//datatable
		public DataTable QueryFirstOrDefault(string query, SqlParameter[] sqlParameters = null!) {
			SqlConnection conn = new SqlConnection( DataBaseConnectionString._connStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(sqlParameters);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			conn.Close();

			return dt;
		}
		//execute
		public int Execute(string query, SqlParameter[] sqlParameters = null!) {
			SqlConnection conn = new SqlConnection(DataBaseConnectionString._connStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(sqlParameters);
			int resultExecute = cmd.ExecuteNonQuery();
			conn.Close();

			return resultExecute;
		}
	}
}
