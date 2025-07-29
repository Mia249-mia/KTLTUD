using System.Configuration;

namespace QLCuaHangDienThoai.DataAccess
{
    public static class ConnectionHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}