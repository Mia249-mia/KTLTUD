using QLCuaHangDienThoai.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCuaHangDienThoai.DataAccess
{
    public class ChiTietHoaDonDAL
    {
        private readonly Database _db;
        public ChiTietHoaDonDAL(Database db)
        {
            _db = db;
        }
        public List<ChiTietHoaDon> GetByMaHD(int maHD)
        {
            var list = new List<ChiTietHoaDon>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM ChiTietHoaDon WHERE MaHD=@MaHD", conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietHoaDon
                        {
                            MaHD = (int)reader["MaHD"],
                            MaSP = (int)reader["MaSP"],
                            SoLuong = (int)reader["SoLuong"],
                            DonGia = (double)reader["DonGia"]
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(ChiTietHoaDon cthd)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)", conn);
                cmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);
                cmd.Parameters.AddWithValue("@MaSP", cthd.MaSP);
                cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", cthd.DonGia);
                cmd.ExecuteNonQuery();
            }
        }
    }
}