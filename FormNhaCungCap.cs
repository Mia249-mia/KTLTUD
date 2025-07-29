using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form qu?n lý nhà cung c?p: cho phép thêm, s?a, xóa, tìm ki?m nhà cung c?p
    public partial class FormNhaCungCap : Form
    {
        // Khai báo các bi?n truy xu?t d? li?u và l?u tr? danh sách
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private NhaCungCapDAL nccDal; // Data Access Layer cho nhà cung c?p
        private List<NhaCungCap> nccList; // Danh sách nhà cung c?p

        public FormNhaCungCap()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // N?p danh sách nhà cung c?p lên l??i
            // Gán s? ki?n cho các nút ch?c n?ng
            btnThemNCC.Click += BtnThemNCC_Click;
            btnSuaNCC.Click += BtnSuaNCC_Click;
            btnXoaNCC.Click += BtnXoaNCC_Click;
            btnTimKiemNCC.Click += BtnTimKiemNCC_Click;
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        // N?p danh sách nhà cung c?p lên DataGridView
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            dgvNhaCungCap.DataSource = nccList.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // X? lý khi nh?n nút Thêm nhà cung c?p
        private void BtnThemNCC_Click(object sender, EventArgs e)
        {
            var ncc = new NhaCungCap
            {
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text,
                SoDienThoai = txtSDTNCC.Text
            };
            nccDal.Insert(ncc); // Thêm nhà cung c?p vào CSDL
            LoadNhaCungCap(); // N?p l?i danh sách nhà cung c?p
        }

        // X? lý khi nh?n nút S?a nhà cung c?p
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
            nccDal.Update(ncc); // C?p nh?t nhà cung c?p trong CSDL
            LoadNhaCungCap(); // N?p l?i danh sách nhà cung c?p
        }

        // X? lý khi nh?n nút Xóa nhà cung c?p
        private void BtnXoaNCC_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            int maNCC = (int)dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value;
            nccDal.Delete(maNCC); // Xóa nhà cung c?p kh?i CSDL
            LoadNhaCungCap(); // N?p l?i danh sách nhà cung c?p
        }

        // X? lý khi nh?n nút Tìm ki?m nhà cung c?p
        private void BtnTimKiemNCC_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNCC.Text.Trim().ToLower();
            var filtered = nccList.Where(x => x.TenNCC.ToLower().Contains(keyword)).ToList();
            dgvNhaCungCap.DataSource = filtered.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // Khi ch?n dòng trên DataGridView thì hi?n th? thông tin lên các ô nh?p li?u
        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value?.ToString();
            txtDiaChiNCC.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value?.ToString();
            txtSDTNCC.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value?.ToString();
        }
    }
}