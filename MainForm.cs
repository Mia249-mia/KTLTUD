using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnNhaCungCap.Click += (s, e) => new FormNhaCungCap().ShowDialog();
            btnSanPham.Click += (s, e) => new FormSanPham().ShowDialog();
            btnBanHang.Click += (s, e) => new FormBanHang().ShowDialog();
            btnThongKe.Click += (s, e) => new FormThongKe().ShowDialog();
        }
    }
}