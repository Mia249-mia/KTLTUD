using System.Windows.Forms;
using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLCuaHangDienThoai
{
    // Form qu?n lý s?n ph?m: cho phép thêm, s?a, xóa, tìm ki?m s?n ph?m
    public partial class FormSanPham : Form
    {
        // Khai báo các bi?n truy xu?t d? li?u và l?u tr? danh sách
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private SanPhamDAL spDal; // Data Access Layer cho s?n ph?m
        private List<SanPham> spList; // Danh sách s?n ph?m
        private List<NhaCungCap> nccList; // Danh sách nhà cung c?p
        private NhaCungCapDAL nccDal; // Data Access Layer cho nhà cung c?p

        public FormSanPham()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            spDal = new SanPhamDAL(db);
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // N?p danh sách nhà cung c?p lên combobox
            LoadSanPham(); // N?p danh sách s?n ph?m lên l??i
            // Gán s? ki?n cho các nút ch?c n?ng
            btnThemSP.Click += BtnThemSP_Click;
            btnSuaSP.Click += BtnSuaSP_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        // N?p danh sách nhà cung c?p lên combobox
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            cbNCCSP.DataSource = nccList;
            cbNCCSP.DisplayMember = "TenNCC";
            cbNCCSP.ValueMember = "MaNCC";
        }

        // N?p danh sách s?n ph?m lên DataGridView
        private void LoadSanPham()
        {
            spList = spDal.GetAll();
            dgvSanPham.DataSource = spList.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // X? lý khi nh?n nút Thêm s?n ph?m
        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                TenSP = txtTenSP.Text,
                DonGia = double.TryParse(txtDonGiaSP.Text, out var dg) ? dg : 0,
                SoLuong = int.TryParse(txtSoLuongSP.Text, out var sl) ? sl : 0,
                MaNCC = (int)cbNCCSP.SelectedValue
            };
            spDal.Insert(sp); // Thêm s?n ph?m vào CSDL
            LoadSanPham(); // N?p l?i danh sách s?n ph?m
        }

        // X? lý khi nh?n nút S?a s?n ph?m
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
            spDal.Update(sp); // C?p nh?t s?n ph?m trong CSDL
            LoadSanPham(); // N?p l?i danh sách s?n ph?m
        }

        // X? lý khi nh?n nút Xóa s?n ph?m
        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
            spDal.Delete(maSP); // Xóa s?n ph?m kh?i CSDL
            LoadSanPham(); // N?p l?i danh sách s?n ph?m
        }

        // X? lý khi nh?n nút Tìm ki?m s?n ph?m
        private void BtnTimKiemSP_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemSP.Text.Trim().ToLower();
            var filtered = spList.Where(x => x.TenSP.ToLower().Contains(keyword)).ToList();
            dgvSanPham.DataSource = filtered.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // Khi ch?n dòng trên DataGridView thì hi?n th? thông tin lên các ô nh?p li?u
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