namespace QLCuaHangDienThoai
{
    partial class FormNhaCungCap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtDiaChiNCC;
        private System.Windows.Forms.TextBox txtSDTNCC;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.TextBox txtTimKiemNCC;
        private System.Windows.Forms.Button btnTimKiemNCC;

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
            dgvNhaCungCap = new DataGridView();
            txtTenNCC = new TextBox();
            txtDiaChiNCC = new TextBox();
            txtSDTNCC = new TextBox();
            btnThemNCC = new Button();
            btnSuaNCC = new Button();
            btnXoaNCC = new Button();
            txtTimKiemNCC = new TextBox();
            btnTimKiemNCC = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
            SuspendLayout();
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.ColumnHeadersHeight = 34;
            dgvNhaCungCap.Font = new Font("Segoe UI", 10F);
            dgvNhaCungCap.Location = new Point(2, 264);
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dgvNhaCungCap.RowHeadersWidth = 62;
            dgvNhaCungCap.Size = new Size(1138, 551);
            dgvNhaCungCap.TabIndex = 0;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Font = new Font("Segoe UI", 10F);
            txtTenNCC.Location = new Point(133, 95);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.PlaceholderText = "Tên NCC";
            txtTenNCC.Size = new Size(487, 34);
            txtTenNCC.TabIndex = 1;
            // 
            // txtDiaChiNCC
            // 
            txtDiaChiNCC.Font = new Font("Segoe UI", 10F);
            txtDiaChiNCC.Location = new Point(133, 135);
            txtDiaChiNCC.Name = "txtDiaChiNCC";
            txtDiaChiNCC.PlaceholderText = "Địa chỉ";
            txtDiaChiNCC.Size = new Size(487, 34);
            txtDiaChiNCC.TabIndex = 2;
            // 
            // txtSDTNCC
            // 
            txtSDTNCC.Font = new Font("Segoe UI", 10F);
            txtSDTNCC.Location = new Point(133, 175);
            txtSDTNCC.Name = "txtSDTNCC";
            txtSDTNCC.PlaceholderText = "SĐT";
            txtSDTNCC.Size = new Size(200, 34);
            txtSDTNCC.TabIndex = 3;
            // 
            // btnThemNCC
            // 
            btnThemNCC.Font = new Font("Segoe UI", 10F);
            btnThemNCC.Location = new Point(348, 175);
            btnThemNCC.Name = "btnThemNCC";
            btnThemNCC.Size = new Size(88, 37);
            btnThemNCC.TabIndex = 4;
            btnThemNCC.Text = "Thêm";
            btnThemNCC.UseVisualStyleBackColor = true;
            // 
            // btnSuaNCC
            // 
            btnSuaNCC.Font = new Font("Segoe UI", 10F);
            btnSuaNCC.Location = new Point(442, 175);
            btnSuaNCC.Name = "btnSuaNCC";
            btnSuaNCC.Size = new Size(85, 37);
            btnSuaNCC.TabIndex = 5;
            btnSuaNCC.Text = "Sửa";
            btnSuaNCC.UseVisualStyleBackColor = true;
            // 
            // btnXoaNCC
            // 
            btnXoaNCC.Font = new Font("Segoe UI", 10F);
            btnXoaNCC.Location = new Point(538, 175);
            btnXoaNCC.Name = "btnXoaNCC";
            btnXoaNCC.Size = new Size(82, 37);
            btnXoaNCC.TabIndex = 6;
            btnXoaNCC.Text = "Xóa";
            btnXoaNCC.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemNCC
            // 
            txtTimKiemNCC.Font = new Font("Segoe UI", 10F);
            txtTimKiemNCC.Location = new Point(133, 17);
            txtTimKiemNCC.Name = "txtTimKiemNCC";
            txtTimKiemNCC.PlaceholderText = "Tìm NCC";
            txtTimKiemNCC.Size = new Size(378, 34);
            txtTimKiemNCC.TabIndex = 7;
            // 
            // btnTimKiemNCC
            // 
            btnTimKiemNCC.Font = new Font("Segoe UI", 10F);
            btnTimKiemNCC.Location = new Point(538, 17);
            btnTimKiemNCC.Name = "btnTimKiemNCC";
            btnTimKiemNCC.Size = new Size(82, 34);
            btnTimKiemNCC.TabIndex = 8;
            btnTimKiemNCC.Text = "Tìm";
            btnTimKiemNCC.UseVisualStyleBackColor = true;
            // 
            // FormNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 827);
            Controls.Add(dgvNhaCungCap);
            Controls.Add(txtTenNCC);
            Controls.Add(txtDiaChiNCC);
            Controls.Add(txtSDTNCC);
            Controls.Add(btnThemNCC);
            Controls.Add(btnSuaNCC);
            Controls.Add(btnXoaNCC);
            Controls.Add(txtTimKiemNCC);
            Controls.Add(btnTimKiemNCC);
            Font = new Font("Segoe UI", 10F);
            Name = "FormNhaCungCap";
            Text = "Quản lý Nhà cung cấp";
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}