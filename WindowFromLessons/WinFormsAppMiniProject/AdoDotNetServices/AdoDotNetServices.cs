using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinFormsAppMiniProject.DataBaseConnection;

namespace WinFormsAppMiniProject
{
	public class AdoDotNetService
	{
		public List<T> Query<T> (string query, SqlParameter[] parameters = null!)
		{
			SqlConnection conn = new SqlConnection(ConnectionString._conStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(parameters);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			conn.Close();

			string jsonStr = JsonConvert.SerializeObject(dt);
			List<T> resList =  JsonConvert.DeserializeObject<List<T>>(jsonStr)!;

			return resList;
		}

		public DataTable QueryFirstOrDefault(string query, SqlParameter[] parameters = null!)
		{
			SqlConnection conn = new SqlConnection(ConnectionString._conStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(parameters);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			conn.Close();

			return dt;
		}

		public int Execute(string query, SqlParameter[] parameters = null!)
		{
			SqlConnection conn = new SqlConnection(ConnectionString._conStr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(parameters);
			int result = cmd.ExecuteNonQuery();
			conn.Close();

			return result;
		}
	}
}
