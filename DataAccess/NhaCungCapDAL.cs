using QLCuaHangDienThoai.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLCuaHangDienThoai.DataAccess
{
    public class NhaCungCapDAL
    {
        private readonly Database _db;
        public NhaCungCapDAL(Database db)
        {
            _db = db;
        }
        public List<NhaCungCap> GetAll()
        {
            var list = new List<NhaCungCap>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM NhaCungCap", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhaCungCap
                        {
                            MaNCC = (int)reader["MaNCC"],
                            TenNCC = reader["TenNCC"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        public void Insert(NhaCungCap ncc)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai) VALUES (@TenNCC, @DiaChi, @SoDienThoai)", conn);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(NhaCungCap ncc)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE NhaCungCap SET TenNCC=@TenNCC, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai WHERE MaNCC=@MaNCC", conn);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int maNCC)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM NhaCungCap WHERE MaNCC=@MaNCC", conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                cmd.ExecuteNonQuery();
            }
        }
    }
}