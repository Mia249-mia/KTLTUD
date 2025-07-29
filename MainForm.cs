using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form chính c?a ?ng d?ng, cho phép truy c?p các ch?c n?ng qu?n lý, bán hàng, th?ng kê
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            // Gán s? ki?n click cho các nút ch?c n?ng ?? m? các form t??ng ?ng
            btnNhaCungCap.Click += (s, e) => new FormNhaCungCap().ShowDialog(); // Qu?n lý nhà cung c?p
            btnSanPham.Click += (s, e) => new FormSanPham().ShowDialog(); // Qu?n lý s?n ph?m
            btnBanHang.Click += (s, e) => new FormBanHang().ShowDialog(); // Bán hàng
            btnThongKe.Click += (s, e) => new FormThongKe().ShowDialog(); // Th?ng kê doanh thu
        }
    }
}