namespace QLCuaHangDienThoai
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbSanPham;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnLuuHoaDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cbSanPham = new ComboBox();
            numSoLuong = new NumericUpDown();
            btnThemSP = new Button();
            dgvHoaDon = new DataGridView();
            lblTongTien = new Label();
            btnLuuHoaDon = new Button();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // cbSanPham
            // 
            cbSanPham.Font = new Font("Segoe UI", 10F);
            cbSanPham.Location = new Point(20, 20);
            cbSanPham.Name = "cbSanPham";
            cbSanPham.Size = new Size(453, 36);
            cbSanPham.TabIndex = 0;
            // 
            // numSoLuong
            // 
            numSoLuong.Font = new Font("Segoe UI", 10F);
            numSoLuong.Location = new Point(509, 22);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(101, 34);
            numSoLuong.TabIndex = 1;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemSP
            // 
            btnThemSP.Font = new Font("Segoe UI", 10F);
            btnThemSP.Location = new Point(640, 22);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(100, 34);
            btnThemSP.TabIndex = 2;
            btnThemSP.Text = "Thêm SP";
            btnThemSP.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeight = 34;
            dgvHoaDon.Font = new Font("Segoe UI", 10F);
            dgvHoaDon.Location = new Point(20, 71);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 62;
            dgvHoaDon.Size = new Size(1061, 389);
            dgvHoaDon.TabIndex = 3;
            // 
            // lblTongTien
            // 
            lblTongTien.Font = new Font("Segoe UI", 10F);
            lblTongTien.Location = new Point(20, 504);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(300, 25);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "Tổng tiền: 0";
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.Font = new Font("Segoe UI", 10F);
            btnLuuHoaDon.Location = new Point(382, 499);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(201, 42);
            btnLuuHoaDon.TabIndex = 5;
            btnLuuHoaDon.Text = "Lưu hóa đơn";
            btnLuuHoaDon.UseVisualStyleBackColor = true;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 600);
            Controls.Add(cbSanPham);
            Controls.Add(numSoLuong);
            Controls.Add(btnThemSP);
            Controls.Add(dgvHoaDon);
            Controls.Add(lblTongTien);
            Controls.Add(btnLuuHoaDon);
            Font = new Font("Segoe UI", 10F);
            Name = "FormBanHang";
            Text = "Bán hàng";
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }
    }
}