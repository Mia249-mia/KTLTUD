using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    // Form qu?n l� nh� cung c?p: cho ph�p th�m, s?a, x�a, t�m ki?m nh� cung c?p
    public partial class FormNhaCungCap : Form
    {
        // Khai b�o c�c bi?n truy xu?t d? li?u v� l?u tr? danh s�ch
        private readonly Database db = new Database(ConnectionHelper.ConnectionString); // K?t n?i CSDL
        private NhaCungCapDAL nccDal; // Data Access Layer cho nh� cung c?p
        private List<NhaCungCap> nccList; // Danh s�ch nh� cung c?p

        public FormNhaCungCap()
        {
            InitializeComponent(); // Kh?i t?o giao di?n
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap(); // N?p danh s�ch nh� cung c?p l�n l??i
            // G�n s? ki?n cho c�c n�t ch?c n?ng
            btnThemNCC.Click += BtnThemNCC_Click;
            btnSuaNCC.Click += BtnSuaNCC_Click;
            btnXoaNCC.Click += BtnXoaNCC_Click;
            btnTimKiemNCC.Click += BtnTimKiemNCC_Click;
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        // N?p danh s�ch nh� cung c?p l�n DataGridView
        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            dgvNhaCungCap.DataSource = nccList.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // X? l� khi nh?n n�t Th�m nh� cung c?p
        private void BtnThemNCC_Click(object sender, EventArgs e)
        {
            var ncc = new NhaCungCap
            {
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text,
                SoDienThoai = txtSDTNCC.Text
            };
            nccDal.Insert(ncc); // Th�m nh� cung c?p v�o CSDL
            LoadNhaCungCap(); // N?p l?i danh s�ch nh� cung c?p
        }

        // X? l� khi nh?n n�t S?a nh� cung c?p
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
            nccDal.Update(ncc); // C?p nh?t nh� cung c?p trong CSDL
            LoadNhaCungCap(); // N?p l?i danh s�ch nh� cung c?p
        }

        // X? l� khi nh?n n�t X�a nh� cung c?p
        private void BtnXoaNCC_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            int maNCC = (int)dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value;
            nccDal.Delete(maNCC); // X�a nh� cung c?p kh?i CSDL
            LoadNhaCungCap(); // N?p l?i danh s�ch nh� cung c?p
        }

        // X? l� khi nh?n n�t T�m ki?m nh� cung c?p
        private void BtnTimKiemNCC_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNCC.Text.Trim().ToLower();
            var filtered = nccList.Where(x => x.TenNCC.ToLower().Contains(keyword)).ToList();
            dgvNhaCungCap.DataSource = filtered.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        // Khi ch?n d�ng tr�n DataGridView th� hi?n th? th�ng tin l�n c�c � nh?p li?u
        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value?.ToString();
            txtDiaChiNCC.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value?.ToString();
            txtSDTNCC.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value?.ToString();
        }
    }
}