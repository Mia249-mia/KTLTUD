namespace QLCuaHangDienThoai
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnNhaCungCap;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnThongKe;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNhaCungCap = new Button();
            btnSanPham = new Button();
            btnBanHang = new Button();
            btnThongKe = new Button();
            SuspendLayout();
            // 
            // btnNhaCungCap
            // 
            btnNhaCungCap.Font = new Font("Segoe UI", 10F);
            btnNhaCungCap.Location = new Point(275, 100);
            btnNhaCungCap.Name = "btnNhaCungCap";
            btnNhaCungCap.Size = new Size(250, 60);
            btnNhaCungCap.TabIndex = 0;
            btnNhaCungCap.Text = "Quản lý Nhà cung cấp";
            btnNhaCungCap.UseVisualStyleBackColor = true;
            // 
            // btnSanPham
            // 
            btnSanPham.Font = new Font("Segoe UI", 10F);
            btnSanPham.Location = new Point(275, 180);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(250, 60);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "Quản lý Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            // 
            // btnBanHang
            // 
            btnBanHang.Font = new Font("Segoe UI", 10F);
            btnBanHang.Location = new Point(275, 260);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(250, 60);
            btnBanHang.TabIndex = 2;
            btnBanHang.Text = "Bán hàng";
            btnBanHang.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Segoe UI", 10F);
            btnThongKe.Location = new Point(275, 340);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(250, 60);
            btnThongKe.TabIndex = 3;
            btnThongKe.Text = "Thống kê doanh thu";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(btnNhaCungCap);
            Controls.Add(btnSanPham);
            Controls.Add(btnBanHang);
            Controls.Add(btnThongKe);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            Text = "Quản lý cửa hàng điện thoại";
            ResumeLayout(false);
        }
        #endregion
    }
}