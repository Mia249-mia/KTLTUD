using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form th?ng k� doanh thu: cho ph�p xem t?ng doanh thu v� s? ??n theo ng�y
    public partial class FormThongKe : Form
    {
        // Khai b�o c�c bi?n truy xu?t d? li?u v� l?u tr? danh s�ch h�a ??n
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private HoaDonDAL hdDal; // Data Access Layer cho h�a ??n
        private List<HoaDon> hdList; // Danh s�ch h�a ??n

        public FormThongKe()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            hdDal = new HoaDonDAL(db);
            btnThongKe.Click += BtnThongKe_Click; // G�n s? ki?n cho n�t Th?ng k�
        }

        // X? l� khi nh?n n�t Th?ng k� doanh thu theo ng�y
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgay.Value.Date; // L?y ng�y ???c ch?n
            hdList = hdDal.GetAll().Where(x => x.NgayLap.Date == ngay).ToList(); // L?c h�a ??n theo ng�y
            dgvHoaDon.DataSource = hdList.Select(x => new { x.MaHD, x.NgayLap, x.TongTien }).ToList(); // Hi?n th? danh s�ch h�a ??n
            lblTongDoanhThu.Text = $"T?ng doanh thu: {hdList.Sum(x => x.TongTien):N0}"; // Hi?n th? t?ng doanh thu
            lblSoDon.Text = $"S? ??n: {hdList.Count}"; // Hi?n th? s? ??n
        }
    }
}