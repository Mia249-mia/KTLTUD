namespace QLCuaHangDienThoai
{
    partial class FormSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtDonGiaSP;
        private System.Windows.Forms.TextBox txtSoLuongSP;
        private System.Windows.Forms.ComboBox cbNCCSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Button btnTimKiemSP;

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
            dgvSanPham = new DataGridView();
            txtTenSP = new TextBox();
            txtDonGiaSP = new TextBox();
            txtSoLuongSP = new TextBox();
            cbNCCSP = new ComboBox();
            btnThemSP = new Button();
            btnSuaSP = new Button();
            btnXoaSP = new Button();
            txtTimKiemSP = new TextBox();
            btnTimKiemSP = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeight = 34;
            dgvSanPham.Font = new Font("Segoe UI", 10F);
            dgvSanPham.Location = new Point(12, 324);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.Size = new Size(1073, 465);
            dgvSanPham.TabIndex = 0;
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Segoe UI", 10F);
            txtTenSP.Location = new Point(140, 94);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.PlaceholderText = "Tên SP";
            txtTenSP.Size = new Size(449, 34);
            txtTenSP.TabIndex = 1;
            // 
            // txtDonGiaSP
            // 
            txtDonGiaSP.Font = new Font("Segoe UI", 10F);
            txtDonGiaSP.Location = new Point(140, 147);
            txtDonGiaSP.Name = "txtDonGiaSP";
            txtDonGiaSP.PlaceholderText = "Đơn giá";
            txtDonGiaSP.Size = new Size(223, 34);
            txtDonGiaSP.TabIndex = 2;
            // 
            // txtSoLuongSP
            // 
            txtSoLuongSP.Font = new Font("Segoe UI", 10F);
            txtSoLuongSP.Location = new Point(392, 147);
            txtSoLuongSP.Name = "txtSoLuongSP";
            txtSoLuongSP.PlaceholderText = "Số lượng";
            txtSoLuongSP.Size = new Size(197, 34);
            txtSoLuongSP.TabIndex = 3;
            // 
            // cbNCCSP
            // 
            cbNCCSP.Font = new Font("Segoe UI", 10F);
            cbNCCSP.Location = new Point(140, 200);
            cbNCCSP.Name = "cbNCCSP";
            cbNCCSP.Size = new Size(449, 36);
            cbNCCSP.TabIndex = 4;
            // 
            // btnThemSP
            // 
            btnThemSP.Font = new Font("Segoe UI", 10F);
            btnThemSP.Location = new Point(299, 247);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(90, 47);
            btnThemSP.TabIndex = 5;
            btnThemSP.Text = "Thêm";
            btnThemSP.UseVisualStyleBackColor = true;
            // 
            // btnSuaSP
            // 
            btnSuaSP.Font = new Font("Segoe UI", 10F);
            btnSuaSP.Location = new Point(407, 247);
            btnSuaSP.Name = "btnSuaSP";
            btnSuaSP.Size = new Size(80, 47);
            btnSuaSP.TabIndex = 6;
            btnSuaSP.Text = "Sửa";
            btnSuaSP.UseVisualStyleBackColor = true;
            // 
            // btnXoaSP
            // 
            btnXoaSP.Font = new Font("Segoe UI", 10F);
            btnXoaSP.Location = new Point(503, 247);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(86, 47);
            btnXoaSP.TabIndex = 7;
            btnXoaSP.Text = "Xóa";
            btnXoaSP.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.Font = new Font("Segoe UI", 10F);
            txtTimKiemSP.Location = new Point(140, 25);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.PlaceholderText = "Tìm SP";
            txtTimKiemSP.Size = new Size(449, 34);
            txtTimKiemSP.TabIndex = 8;
            // 
            // btnTimKiemSP
            // 
            btnTimKiemSP.Font = new Font("Segoe UI", 10F);
            btnTimKiemSP.Location = new Point(605, 25);
            btnTimKiemSP.Name = "btnTimKiemSP";
            btnTimKiemSP.Size = new Size(78, 41);
            btnTimKiemSP.TabIndex = 9;
            btnTimKiemSP.Text = "Tìm";
            btnTimKiemSP.UseVisualStyleBackColor = true;
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 801);
            Controls.Add(dgvSanPham);
            Controls.Add(txtTenSP);
            Controls.Add(txtDonGiaSP);
            Controls.Add(txtSoLuongSP);
            Controls.Add(cbNCCSP);
            Controls.Add(btnThemSP);
            Controls.Add(btnSuaSP);
            Controls.Add(btnXoaSP);
            Controls.Add(txtTimKiemSP);
            Controls.Add(btnTimKiemSP);
            Font = new Font("Segoe UI", 10F);
            Name = "FormSanPham";
            Text = "Quản lý Sản phẩm";
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}