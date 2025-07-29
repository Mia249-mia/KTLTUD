using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form ch�nh c?a ?ng d?ng, cho ph�p truy c?p c�c ch?c n?ng qu?n l�, b�n h�ng, th?ng k�
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            // G�n s? ki?n click cho c�c n�t ch?c n?ng ?? m? c�c form t??ng ?ng
            btnNhaCungCap.Click += (s, e) => new FormNhaCungCap().ShowDialog(); // Qu?n l� nh� cung c?p
            btnSanPham.Click += (s, e) => new FormSanPham().ShowDialog(); // Qu?n l� s?n ph?m
            btnBanHang.Click += (s, e) => new FormBanHang().ShowDialog(); // B�n h�ng
            btnThongKe.Click += (s, e) => new FormThongKe().ShowDialog(); // Th?ng k� doanh thu
        }
    }
}