using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form quản lý nhà cung cấp: cho phép thêm, sửa, xóa, tìm kiếm nhà cung cấp
    public partial class FormNhaCungCap : Form
    {
        // Khai báo các biến truy xuất dữ liệu và lưu trữ danh sách
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // Kết nối CSDL
        private NhaCungCapDAL nccDal; // Data Access Layer cho nhà cung cấp
        private List<NhaCungCap> nccList; // Danh sách nhà cung cấp

        public FormNhaCungCap()
        {
            InitializeComponent(); // Khởi tạo giao diện
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // Nạp danh sách nhà cung cấp lên lưới
            // Gán sự kiện cho các nút chức năng
            btnThemNCC.Click += BtnThemNCC_Click;
            btnSuaNCC.Click += BtnSuaNCC_Click;
            btnXoaNCC.Click += BtnXoaNCC_Click;
            btnTimKiemNCC.Click += BtnTimKiemNCC_Click;
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        // Nạp danh sách nhà cung cấp lên DataGridView
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            dgvNhaCungCap.DataSource = nccList.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // Xử lý khi nhấn nút Thêm nhà cung cấp
        private void BtnThemNCC_Click(object sender, EventArgs e)
        {
            var ncc = new NhaCungCap
            {
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text,
                SoDienThoai = txtSDTNCC.Text
            };
            nccDal.Insert(ncc); // Thêm nhà cung cấp vào CSDL
            LoadNhaCungCap(); // Nạp lại danh sách nhà cung cấp
        }

        // Xử lý khi nhấn nút Sửa nhà cung cấp
        private void BtnSuaNCC_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            int maNCC = (int)dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value;
            var ncc = new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text,
                SoDienThoai = txtSDTNCC.Text
            };
            nccDal.Update(ncc); // Cập nhật nhà cung cấp trong CSDL
            LoadNhaCungCap(); // Nạp lại danh sách nhà cung cấp
        }

        // Xử lý khi nhấn nút Xóa nhà cung cấp
        private void BtnXoaNCC_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            int maNCC = (int)dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value;
            nccDal.Delete(maNCC); // Xóa nhà cung cấp khỏi CSDL
            LoadNhaCungCap(); // Nạp lại danh sách nhà cung cấp
        }

        // Xử lý khi nhấn nút Tìm kiếm nhà cung cấp
        private void BtnTimKiemNCC_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNCC.Text.Trim().ToLower();
            var filtered = nccList.Where(x => x.TenNCC.ToLower().Contains(keyword)).ToList();
            dgvNhaCungCap.DataSource = filtered.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // Khi chọn dòng trên DataGridView thì hiển thị thông tin lên các ô nhập liệu
        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value?.ToString();
            txtDiaChiNCC.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value?.ToString();
            txtSDTNCC.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value?.ToString();
        }
    }
}