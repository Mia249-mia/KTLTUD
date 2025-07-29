using System.Windows.Forms;
using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLCuaHangDienThoai
{
    // Form quản lý sản phẩm: cho phép thêm, sửa, xóa, tìm kiếm sản phẩm
    public partial class FormSanPham : Form
    {
        // Khai báo các biến truy xuất dữ liệu và lưu trữ danh sách
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // Kết nối CSDL
        private SanPhamDAL spDal; // Data Access Layer cho sản phẩm
        private List<SanPham> spList; // Danh sách sản phẩm
        private List<NhaCungCap> nccList; // Danh sách nhà cung cấp
        private NhaCungCapDAL nccDal; // Data Access Layer cho nhà cung cấp

        public FormSanPham()
        {
            InitializeComponent(); // Khởi tạo giao diện
            spDal = new SanPhamDAL(db);
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // Nạp danh sách nhà cung cấp lên combobox
            LoadSanPham(); // Nạp danh sách sản phẩm lên lưới
            // Gán sự kiện cho các nút chức năng
            btnThemSP.Click += BtnThemSP_Click;
            btnSuaSP.Click += BtnSuaSP_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        // Nạp danh sách nhà cung cấp lên combobox
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            cbNCCSP.DataSource = nccList;
            cbNCCSP.DisplayMember = "TenNCC";
            cbNCCSP.ValueMember = "MaNCC";
        }

        // Nạp danh sách sản phẩm lên DataGridView
        private void LoadSanPham()
        {
            spList = spDal.GetAll();
            dgvSanPham.DataSource = spList.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // Xử lý khi nhấn nút Thêm sản phẩm
        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                TenSP = txtTenSP.Text,
                DonGia = double.TryParse(txtDonGiaSP.Text, out var dg) ? dg : 0,
                SoLuong = int.TryParse(txtSoLuongSP.Text, out var sl) ? sl : 0,
                MaNCC = (int)cbNCCSP.SelectedValue
            };
            spDal.Insert(sp); // Thêm sản phẩm vào CSDL
            LoadSanPham(); // Nạp lại danh sách sản phẩm
        }

        // Xử lý khi nhấn nút Sửa sản phẩm
        private void BtnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
            var sp = new SanPham
            {
                MaSP = maSP,
                TenSP = txtTenSP.Text,
                DonGia = double.TryParse(txtDonGiaSP.Text, out var dg) ? dg : 0,
                SoLuong = int.TryParse(txtSoLuongSP.Text, out var sl) ? sl : 0,
                MaNCC = (int)cbNCCSP.SelectedValue
            };
            spDal.Update(sp); // Cập nhật sản phẩm trong CSDL
            LoadSanPham(); // Nạp lại danh sách sản phẩm
        }

        // Xử lý khi nhấn nút Xóa sản phẩm
        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
            spDal.Delete(maSP); // Xóa sản phẩm khỏi CSDL
            LoadSanPham(); // Nạp lại danh sách sản phẩm
        }

        // Xử lý khi nhấn nút Tìm kiếm sản phẩm
        private void BtnTimKiemSP_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemSP.Text.Trim().ToLower();
            var filtered = spList.Where(x => x.TenSP.ToLower().Contains(keyword)).ToList();
            dgvSanPham.DataSource = filtered.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // Khi chọn dòng trên DataGridView thì hiển thị thông tin lên các ô nhập liệu
        private void DgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            txtTenSP.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value?.ToString();
            txtDonGiaSP.Text = dgvSanPham.CurrentRow.Cells["DonGia"].Value?.ToString();
            txtSoLuongSP.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value?.ToString();
            int maNCC = (int)dgvSanPham.CurrentRow.Cells["MaNCC"].Value;
            cbNCCSP.SelectedValue = maNCC;
        }
    }
}