using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    public partial class FormBanHang : Form
    {
        private readonly Database db = new Database(ConnectionHelper.ConnectionString);
        private SanPhamDAL spDal;
        private HoaDonDAL hdDal;
        private ChiTietHoaDonDAL cthdDal;
        private List<SanPham> spList;
        private List<(int MaSP, string TenSP, double DonGia, int SoLuong)> gioHang = new();

        public FormBanHang()
        {
            InitializeComponent();
            spDal = new SanPhamDAL(db);
            hdDal = new HoaDonDAL(db);
            cthdDal = new ChiTietHoaDonDAL(db);
            LoadSanPham();
            btnThemSP.Click += BtnThemSP_Click;
            btnLuuHoaDon.Click += BtnLuuHoaDon_Click;
        }

        private void LoadSanPham()
        {
            spList = spDal.GetAll();
            cbSanPham.DataSource = spList;
            cbSanPham.DisplayMember = "TenSP";
            cbSanPham.ValueMember = "MaSP";
        }

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedItem is not SanPham sp) return;
            int soLuong = (int)numSoLuong.Value;
            if (soLuong > sp.SoLuong)
            {
                MessageBox.Show("Số lượng tồn kho không đủ!");
                return;
            }
            var existing = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (existing.MaSP != 0)
            {
                gioHang.Remove(existing);
                gioHang.Add((sp.MaSP, sp.TenSP, sp.DonGia, existing.SoLuong + soLuong));
            }
            else
            {
                gioHang.Add((sp.MaSP, sp.TenSP, sp.DonGia, soLuong));
            }
            CapNhatGioHang();
        }

        private void CapNhatGioHang()
        {
            dgvHoaDon.DataSource = gioHang.Select(x => new { x.MaSP, x.TenSP, x.DonGia, x.SoLuong, ThanhTien = x.DonGia * x.SoLuong }).ToList();
            double tong = gioHang.Sum(x => x.DonGia * x.SoLuong);
            lblTongTien.Text = $"Tổng tiền: {tong:N0}";
        }

        private void BtnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong hóa đơn!");
                return;
            }
            double tongTien = gioHang.Sum(x => x.DonGia * x.SoLuong);
            var hd = new HoaDon { NgayLap = DateTime.Now, TongTien = tongTien };
            int maHD = hdDal.Insert(hd);
            foreach (var item in gioHang)
            {
                var cthd = new ChiTietHoaDon { MaHD = maHD, MaSP = item.MaSP, SoLuong = item.SoLuong, DonGia = item.DonGia };
                cthdDal.Insert(cthd);
                // Trừ tồn kho
                var sp = spList.First(s => s.MaSP == item.MaSP);
                sp.SoLuong -= item.SoLuong;
                spDal.Update(sp);
            }
            MessageBox.Show($"Lưu hóa đơn thành công! Mã hóa đơn: {maHD}");
            gioHang.Clear();
            CapNhatGioHang();
            LoadSanPham();
        }
    }
}