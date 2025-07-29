using System.Windows.Forms;
using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLCuaHangDienThoai
{
    public partial class FormSanPham : Form
    {
        private readonly Database db = new Database(ConnectionHelper.ConnectionString);
        private SanPhamDAL spDal;
        private List<SanPham> spList;
        private List<NhaCungCap> nccList;
        private NhaCungCapDAL nccDal;

        public FormSanPham()
        {
            InitializeComponent();
            spDal = new SanPhamDAL(db);
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap();
            LoadSanPham();
            btnThemSP.Click += BtnThemSP_Click;
            btnSuaSP.Click += BtnSuaSP_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnTimKiemSP.Click += BtnTimKiemSP_Click;
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            cbNCCSP.DataSource = nccList;
            cbNCCSP.DisplayMember = "TenNCC";
            cbNCCSP.ValueMember = "MaNCC";
        }

        private void LoadSanPham()
        {
            spList = spDal.GetAll();
            dgvSanPham.DataSource = spList.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                TenSP = txtTenSP.Text,
                DonGia = double.TryParse(txtDonGiaSP.Text, out var dg) ? dg : 0,
                SoLuong = int.TryParse(txtSoLuongSP.Text, out var sl) ? sl : 0,
                MaNCC = (int)cbNCCSP.SelectedValue
            };
            spDal.Insert(sp);
            LoadSanPham();
        }

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
            spDal.Update(sp);
            LoadSanPham();
        }

        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int maSP = (int)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
            spDal.Delete(maSP);
            LoadSanPham();
        }

        private void BtnTimKiemSP_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemSP.Text.Trim().ToLower();
            var filtered = spList.Where(x => x.TenSP.ToLower().Contains(keyword)).ToList();
            dgvSanPham.DataSource = filtered.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, x.MaNCC }).ToList();
        }

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