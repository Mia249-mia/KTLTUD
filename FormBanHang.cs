using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form bán hàng: cho phép chọn sản phẩm, nhập số lượng, tạo hóa đơn và lưu vào CSDL
    public partial class FormBanHang : Form
    {
        // Khai báo các biến truy xuất dữ liệu và lưu trữ giỏ hàng
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // Kết nối CSDL
        private SanPhamDAL spDal; // Data Access Layer cho sản phẩm
        private HoaDonDAL hdDal; // Data Access Layer cho hóa đơn
        private ChiTietHoaDonDAL cthdDal; // Data Access Layer cho chi tiết hóa đơn
        private List<SanPham> spList; // Danh sách sản phẩm lấy từ CSDL
        private List<(int MaSP, string TenSP, double DonGia, int SoLuong)> gioHang = new(); // Giỏ hàng tạm thời

        public FormBanHang()
        {
            InitializeComponent(); // Khởi tạo giao diện
            spDal = new SanPhamDAL(db);
            hdDal = new HoaDonDAL(db);
            cthdDal = new ChiTietHoaDonDAL(db);
            LoadSanPham(); // Nạp danh sách sản phẩm lên combobox
            // Gán sự kiện click cho các nút
            btnThemSP.Click += BtnThemSP_Click;
            btnLuuHoaDon.Click += BtnLuuHoaDon_Click;
        }

        // Hàm nạp danh sách sản phẩm lên combobox
        private void LoadSanPham()
        {
            spList = spDal.GetAll(); // Lấy tất cả sản phẩm từ CSDL
            cbSanPham.DataSource = spList;
            cbSanPham.DisplayMember = "TenSP"; // Hiển thị tên sản phẩm
            cbSanPham.ValueMember = "MaSP"; // Giá trị là mã sản phẩm
        }

        // Xử lý khi nhấn nút Thêm sản phẩm vào giỏ hàng
        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedItem is not SanPham sp) return; // Nếu chưa chọn sản phẩm thì thoát
            int soLuong = (int)numSoLuong.Value; // Lấy số lượng người dùng nhập
            if (soLuong > sp.SoLuong)
            {
                MessageBox.Show("Số lượng tồn kho không đủ!"); // Kiểm tra tồn kho
                return;
            }
            // Kiểm tra sản phẩm đã có trong giỏ chưa
            var existing = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (existing.MaSP != 0)
            {
                // Nếu đã có thì cộng dồn số lượng
                gioHang.Remove(existing);
                gioHang.Add((sp.MaSP, sp.TenSP, sp.DonGia, existing.SoLuong + soLuong));
            }
            else
            {
                // Nếu chưa có thì thêm mới vào giỏ
                gioHang.Add((sp.MaSP, sp.TenSP, sp.DonGia, soLuong));
            }
            CapNhatGioHang(); // Cập nhật lại hiển thị giỏ hàng
        }

        // Hàm cập nhật lại DataGridView hiển thị giỏ hàng và tổng tiền
        private void CapNhatGioHang()
        {
            // Hiển thị danh sách sản phẩm trong giỏ hàng lên lưới
            dgvHoaDon.DataSource = gioHang.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, ThanhTien = x.DonGia * x.SoLuong }).ToList();
            // Tính tổng tiền của tất cả sản phẩm trong giỏ
            double tong = gioHang.Sum(x => x.DonGia * x.SoLuong);
            lblTongTien.Text = $"Tổng tiền: {tong:N0}";
        }

        // Xử lý khi nhấn nút Lưu hóa đơn
        private void BtnLuuHoaDon_Click(object sender, EventArgs e)
        {
            // Nếu giỏ hàng rỗng thì báo lỗi
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong hóa đơn!");
                return;
            }
            // Tính tổng tiền hóa đơn
            double tongTien = gioHang.Sum(x => x.DonGia * x.SoLuong);
            // Tạo mới hóa đơn và lưu vào CSDL
            var hd = new HoaDon { NgayLap = DateTime.Now, TongTien = tongTien };
            int maHD = hdDal.Insert(hd);
            // Lưu từng sản phẩm trong giỏ vào bảng ChiTietHoaDon và cập nhật lại số lượng tồn kho
            foreach (var item in gioHang)
            {
                var cthd = new ChiTietHoaDon { MaHD = maHD, MaSP = item.MaSP, SoLuong = item.SoLuong, DonGia = item.DonGia };
                cthdDal.Insert(cthd);
                // Trừ số lượng tồn kho của sản phẩm
                var sp = spList.First(s => s.MaSP == item.MaSP);
                sp.SoLuong -= item.SoLuong;
                spDal.Update(sp);
            }
            MessageBox.Show($"Lưu hóa đơn thành công! Mã hóa đơn: {maHD}");
            gioHang.Clear(); // Xóa giỏ hàng sau khi lưu
            CapNhatGioHang(); // Cập nhật lại hiển thị
            LoadSanPham(); // Nạp lại danh sách sản phẩm (cập nhật tồn kho)
        }
    }
}