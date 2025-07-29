using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form thống kê doanh thu: cho phép xem tổng doanh thu và số đơn theo ngày
    public partial class FormThongKe : Form
    {
        // Khai báo các biến truy xuất dữ liệu và lưu trữ danh sách hóa đơn
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // Kết nối CSDL
        private HoaDonDAL hdDal; // Data Access Layer cho hóa đơn
        private List<HoaDon> hdList; // Danh sách hóa đơn

        public FormThongKe()
        {
            InitializeComponent(); // Khởi tạo giao diện
            hdDal = new HoaDonDAL(db);
            btnThongKe.Click += BtnThongKe_Click; // Gán sự kiện cho nút Thống kê
        }

        // Xử lý khi nhấn nút Thống kê doanh thu theo ngày
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgay.Value.Date; // Lấy ngày được chọn
            hdList = hdDal.GetAll().Where(x => x.NgayLap.Date == ngay).ToList(); // Lọc hóa đơn theo ngày
            dgvHoaDon.DataSource = hdList.Select(x => new { x.MaHD, x.NgayLap, x.TongTien }).ToList(); // Hiển thị danh sách hóa đơn
            lblTongDoanhThu.Text = $"Tổng doanh thu: {hdList.Sum(x => x.TongTien):N0}"; // Hiển thị tổng doanh thu
            lblSoDon.Text = $"Số đơn: {hdList.Count}"; // Hiển thị số đơn
        }
    }
}