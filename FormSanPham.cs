using System.Windows.Forms;
using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLCuaHangDienThoai
{
    // Form qu?n l� s?n ph?m: cho ph�p th�m, s?a, x�a, t�m ki?m s?n ph?m
    public partial class FormSanPham : Form
    {
        // Khai b�o c�c bi?n truy xu?t d? li?u v� l?u tr? danh s�ch
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private SanPhamDAL spDal; // Data Access Layer cho s?n ph?m
        private List<SanPham> spList; // Danh s�ch s?n ph?m
        private List<NhaCungCap> nccList; // Danh s�ch nh� cung c?p
        private NhaCungCapDAL nccDal; // Data Access Layer cho nh� cung c?p

        public FormSanPham()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            spDal = new SanPhamDAL(db);
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // N?p danh s�ch nh� cung c?p l�n combobox
            LoadSanPham(); // N?p danh s�ch s?n ph?m l�n l??i
            // G�n s? ki?n cho c�c n�t ch?c n?ng
            btnThemSP.Click += BtnThemSP_Click;
            btnSuaSP.Click += BtnSuaSP_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        // N?p danh s�ch nh� cung c?p l�n combobox
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            cbNCCSP.DataSource = nccList;
            cbNCCSP.DisplayMember = "TenNCC";
            cbNCCSP.ValueMember = "MaNCC";
        }

        // N?p danh s�ch s?n ph?m l�n DataGridView
        private void LoadSanPham()
        {
            spList = spDal.GetAll();
            dgvSanPham.DataSource = spList.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // X? l� khi nh?n n�t Th�m s?n ph?m
        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                TenSP = txtTenSP.Text,
                DonGia = double.TryParse(txtDonGiaSP.Text, out var dg) ? dg : 0,
                SoLuong = int.TryParse(txtSoLuongSP.Text, out var sl) ? sl : 0,
                MaNCC = (int)cbNCCSP.SelectedValue
            };
            spDal.Insert(sp); // Th�m s?n ph?m v�o CSDL
            LoadSanPham(); // N?p l?i danh s�ch s?n ph?m
        }

        // X? l� khi nh?n n�t S?a s?n ph?m
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
            LoadSanPham(); // N?p l?i danh s�ch s?n ph?m
        }

        // X? l� khi nh?n n�t X�a s?n ph?m
        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
            spDal.Delete(maSP); // X�a s?n ph?m kh?i CSDL
            LoadSanPham(); // N?p l?i danh s�ch s?n ph?m
        }

        // X? l� khi nh?n n�t T�m ki?m s?n ph?m
        private void BtnTimKiemSP_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemSP.Text.Trim().ToLower();
            var filtered = spList.Where(x => x.TenSP.ToLower().Contains(keyword)).ToList();
            dgvSanPham.DataSource = filtered.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        // Khi ch?n d�ng tr�n DataGridView th� hi?n th? th�ng tin l�n c�c � nh?p li?u
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