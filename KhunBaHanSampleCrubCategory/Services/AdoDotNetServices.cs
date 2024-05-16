using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace KhunBaHanSampleCrubCategory.Services
{
    public class AdoDotNetServices
    {
        private readonly IConfiguration? _configuration;

        public AdoDotNetServices(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public List<T> Query<T>(string query, SqlParameter[] sqlParameters = null!)
        {
            SqlConnection conn = new SqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            string jsonStr = JsonConvert.SerializeObject(dt);
            List<T> restLst = JsonConvert.DeserializeObject<List<T>>(jsonStr)!;

            return restLst;
        }

        public DataTable QueryFirstOrDefault(string query, SqlParameter[] sqlParameters = null!) {
            SqlConnection conn = new SqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        public int Execute(string query, SqlParameter[] sqlParameters = null!) {
            SqlConnection conn = new SqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(sqlParameters);
            int resExecute = cmd.ExecuteNonQuery();
            conn.Close();

            return resExecute;
        }
    }
}
