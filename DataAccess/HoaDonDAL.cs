using QLCuaHangDienThoai.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCuaHangDienThoai.DataAccess
{
    public class HoaDonDAL
    {
        private readonly Database _db;
        public HoaDonDAL(Database db)
        {
            _db = db;
        }
        public List<HoaDon> GetAll()
        {
            var list = new List<HoaDon>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM HoaDon", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new HoaDon
                        {
                            MaHD = (int)reader["MaHD"],
                            NgayLap = (DateTime)reader["NgayLap"],
                            TongTien = (double)reader["TongTien"]
                        });
                    }
                }
            }
            return list;
        }
        public int Insert(HoaDon hd)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO HoaDon (NgayLap, TongTien) OUTPUT INSERTED.MaHD VALUES (@NgayLap, @TongTien)", conn);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                return (int)cmd.ExecuteScalar();
            }
        }
        public void UpdateTongTien(int maHD, double tongTien)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE HoaDon SET TongTien=@TongTien WHERE MaHD=@MaHD", conn);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.ExecuteNonQuery();
            }
        }
    }
}