namespace QLCuaHangDienThoai
{
    partial class FormThongKe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblSoDon;

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
            dtpNgay = new DateTimePicker();
            btnThongKe = new Button();
            dgvHoaDon = new DataGridView();
            lblTongDoanhThu = new Label();
            lblSoDon = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // dtpNgay
            // 
            dtpNgay.Font = new Font("Segoe UI", 10F);
            dtpNgay.Format = DateTimePickerFormat.Short;
            dtpNgay.Location = new Point(20, 20);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(200, 34);
            dtpNgay.TabIndex = 0;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Segoe UI", 10F);
            btnThongKe.Location = new Point(230, 20);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(190, 30);
            btnThongKe.TabIndex = 1;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeight = 34;
            dgvHoaDon.Font = new Font("Segoe UI", 10F);
            dgvHoaDon.Location = new Point(20, 60);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 62;
            dgvHoaDon.Size = new Size(840, 400);
            dgvHoaDon.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Font = new Font("Segoe UI", 10F);
            lblTongDoanhThu.Location = new Point(20, 470);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(300, 25);
            lblTongDoanhThu.TabIndex = 3;
            lblTongDoanhThu.Text = "Tổng doanh thu: 0";
            // 
            // lblSoDon
            // 
            lblSoDon.Font = new Font("Segoe UI", 10F);
            lblSoDon.Location = new Point(350, 470);
            lblSoDon.Name = "lblSoDon";
            lblSoDon.Size = new Size(200, 25);
            lblSoDon.TabIndex = 4;
            lblSoDon.Text = "Số đơn: 0";
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(dtpNgay);
            Controls.Add(btnThongKe);
            Controls.Add(dgvHoaDon);
            Controls.Add(lblTongDoanhThu);
            Controls.Add(lblSoDon);
            Font = new Font("Segoe UI", 10F);
            Name = "FormThongKe";
            Text = "Thống kê doanh thu";
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }
    }
}