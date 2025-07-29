using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form chính của ứng dụng, cho phép truy cập các chức năng quản lý, bán hàng, thống kê
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Khởi tạo giao diện
            // Gán sự kiện click cho các nút chức năng để mở các form tương ứng
            btnNhaCungCap.Click += (s, e) => new FormNhaCungCap().ShowDialog(); // Quản lý nhà cung cấp
            btnSanPham.Click += (s, e) => new FormSanPham().ShowDialog(); // Quản lý sản phẩm
            btnBanHang.Click += (s, e) => new FormBanHang().ShowDialog(); // Bán hàng
            btnThongKe.Click += (s, e) => new FormThongKe().ShowDialog(); // Thống kê doanh thu
        }
    }
}