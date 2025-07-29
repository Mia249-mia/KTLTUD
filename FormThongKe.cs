using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form th?ng kê doanh thu: cho phép xem t?ng doanh thu và s? ??n theo ngày
    public partial class FormThongKe : Form
    {
        // Khai báo các bi?n truy xu?t d? li?u và l?u tr? danh sách hóa ??n
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private HoaDonDAL hdDal; // Data Access Layer cho hóa ??n
        private List<HoaDon> hdList; // Danh sách hóa ??n

        public FormThongKe()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            hdDal = new HoaDonDAL(db);
            btnThongKe.Click += BtnThongKe_Click; // Gán s? ki?n cho nút Th?ng kê
        }

        // X? lý khi nh?n nút Th?ng kê doanh thu theo ngày
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgay.Value.Date; // L?y ngày ???c ch?n
            hdList = hdDal.GetAll().Where(x => x.NgayLap.Date == ngay).ToList(); // L?c hóa ??n theo ngày
            dgvHoaDon.DataSource = hdList.Select(x => new { x.MaHD, x.NgayLap, x.TongTien }).ToList(); // Hi?n th? danh sách hóa ??n
            lblTongDoanhThu.Text = $"T?ng doanh thu: {hdList.Sum(x => x.TongTien):N0}"; // Hi?n th? t?ng doanh thu
            lblSoDon.Text = $"S? ??n: {hdList.Count}"; // Hi?n th? s? ??n
        }
    }
}