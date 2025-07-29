using QLCuaHangDienThoai.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCuaHangDienThoai.DataAccess
{
    public class SanPhamDAL
    {
        private readonly Database _db;
        public SanPhamDAL(Database db)
        {
            _db = db;
        }
        public List<SanPham> GetAll()
        {
            var list = new List<SanPham>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SanPham", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPham
                        {
                            MaSP = (int)reader["MaSP"],
                            TenSP = reader["TenSP"].ToString(),
                            DonGia = (double)reader["DonGia"],
                            SoLuong = (int)reader["SoLuong"],
                            MaNCC = (int)reader["MaNCC"]
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(SanPham sp)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO SanPham (TenSP, DonGia, SoLuong, MaNCC) VALUES (@TenSP, @DonGia, @SoLuong, @MaNCC)", conn);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("@MaNCC", sp.MaNCC);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(SanPham sp)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE SanPham SET TenSP=@TenSP, DonGia=@DonGia, SoLuong=@SoLuong, MaNCC=@MaNCC WHERE MaSP=@MaSP", conn);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("@MaNCC", sp.MaNCC);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int maSP)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM SanPham WHERE MaSP=@MaSP", conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.ExecuteNonQuery();
            }
        }
    }
}