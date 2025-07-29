using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    public partial class FormNhaCungCap : Form
    {
        private readonly Database db = new Database(ConnectionHelper.ConnectionString);
        private NhaCungCapDAL nccDal;
        private List<NhaCungCap> nccList;

        public FormNhaCungCap()
        {
            InitializeComponent();
            nccDal = new NhaCungCapDAL(db);
            LoadNhaCungCap();
            btnThemNCC.Click += BtnThemNCC_Click;
            btnSuaNCC.Click += BtnSuaNCC_Click;
            btnXoaNCC.Click += BtnXoaNCC_Click;
            btnTimKiemNCC.Click += BtnTimKiemNCC_Click;
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        private void LoadNhaCungCap()
        {
            nccList = nccDal.GetAll();
            dgvNhaCungCap.DataSource = nccList.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        private void BtnThemNCC_Click(object sender, EventArgs e)
        {
            var ncc = new NhaCungCap
            {
                TenNCC = txtTenNCC.Text,
                DiaChi = txtDiaChiNCC.Text,
                SoDienThoai = txtSDTNCC.Text
            };
            nccDal.Insert(ncc);
            LoadNhaCungCap();
        }

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
            nccDal.Update(ncc);
            LoadNhaCungCap();
        }

        private void BtnXoaNCC_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            int maNCC = (int)dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value;
            nccDal.Delete(maNCC);
            LoadNhaCungCap();
        }

        private void BtnTimKiemNCC_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNCC.Text.Trim().ToLower();
            var filtered = nccList.Where(x => x.TenNCC.ToLower().Contains(keyword)).ToList();
            dgvNhaCungCap.DataSource = filtered.Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SoDienThoai }).ToList();
        }

        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow == null) return;
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value?.ToString();
            txtDiaChiNCC.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value?.ToString();
            txtSDTNCC.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value?.ToString();
        }
    }
}