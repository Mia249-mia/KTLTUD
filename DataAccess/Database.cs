using System.Data.SqlClient;

namespace QLCuaHangDienThoai.DataAccess
{
    public class Database
    {
        private readonly string _connectionString;
        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}