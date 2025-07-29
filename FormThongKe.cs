using QLCuaHangDienThoai.DataAccess;
using QLCuaHangDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangDienThoai
{
    public partial class FormThongKe : Form
    {
        private readonly Database db = new Database(ConnectionHelper.ConnectionString);
        private HoaDonDAL hdDal;
        private List<HoaDon> hdList;

        public FormThongKe()
        {
            InitializeComponent();
            hdDal = new HoaDonDAL(db);
            btnThongKe.Click += BtnThongKe_Click;
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgay.Value.Date;
            hdList = hdDal.GetAll().Where(x => x.NgayLap.Date == ngay).ToList();
            dgvHoaDon.DataSource = hdList.Select(x => new { x.MaHD, x.NgayLap, x.TongTien }).ToList();
            lblTongDoanhThu.Text = $"T?ng doanh thu: {hdList.Sum(x => x.TongTien):N0}";
            lblSoDon.Text = $"S? ??n: {hdList.Count}";
        }
    }
}