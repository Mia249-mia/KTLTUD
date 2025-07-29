# Quản lý cửa hàng điện thoại

Ứng dụng WinForms quản lý cửa hàng điện thoại, hỗ trợ quản lý sản phẩm, nhà cung cấp, bán hàng và thống kê doanh thu.

## Tính năng chính
- Quản lý nhà cung cấp (thêm, sửa, xóa, tìm kiếm)
- Quản lý sản phẩm (thêm, sửa, xóa, tìm kiếm)
- Bán hàng: tạo hóa đơn, chọn sản phẩm, nhập số lượng, tự động tính tổng tiền, lưu hóa đơn
- Thống kê doanh thu theo ngày

## Công nghệ sử dụng
- .NET 8 WinForms (C#)
- SQL Server (mặc định: `localhost\SQLEXPRESS`)
- ADO.NET (System.Data.SqlClient)

## Cấu trúc giao diện
- **MainForm**: Menu các chức năng chính bằng button
- **FormNhaCungCap**: Quản lý nhà cung cấp
- **FormSanPham**: Quản lý sản phẩm
- **FormBanHang**: Bán hàng, tạo hóa đơn
- **FormThongKe**: Thống kê doanh thu

## Cấu trúc CSDL (SQL Server)
```sql
CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY IDENTITY,
    TenNCC NVARCHAR(100),
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(20)
);

CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY IDENTITY,
    TenSP NVARCHAR(100),
    DonGia FLOAT,
    SoLuong INT,
    MaNCC INT FOREIGN KEY REFERENCES NhaCungCap(MaNCC)
);

CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY,
    NgayLap DATE,
    TongTien FLOAT
);

CREATE TABLE ChiTietHoaDon (
    MaHD INT,
    MaSP INT,
    SoLuong INT,
    DonGia FLOAT,
    PRIMARY KEY(MaHD, MaSP),
    FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
);
```

## Dữ liệu mẫu (Nhà cung cấp & Sản phẩm)
```sql
DELETE FROM SanPham;
DELETE FROM NhaCungCap;
DBCC CHECKIDENT ('NhaCungCap', RESEED, 0);

-- Thêm dữ liệu mẫu cho bảng Nhà cung cấp (12 dòng)
INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai) VALUES
(N'Công ty Samsung', N'123 Lê Lợi, Q1, TP.HCM', '0909123456'),
(N'Công ty Apple', N'456 Nguyễn Huệ, Q1, TP.HCM', '0911222333'),
(N'Công ty Xiaomi', N'789 Trần Hưng Đạo, Q5, TP.HCM', '0933444555'),
(N'Công ty Oppo', N'12 Cách Mạng, Q3, TP.HCM', '0909888777'),
(N'Công ty Vivo', N'34 Lý Thường Kiệt, Q10, TP.HCM', '0911666777'),
(N'Công ty Realme', N'56 Nguyễn Trãi, Q5, TP.HCM', '0922333444'),
(N'Công ty Nokia', N'78 Hai Bà Trưng, Q1, TP.HCM', '0933555666'),
(N'Công ty Sony', N'90 Điện Biên Phủ, Q3, TP.HCM', '0944777888'),
(N'Công ty Asus', N'11 Nguyễn Văn Cừ, Q5, TP.HCM', '0955999000'),
(N'Công ty Lenovo', N'22 Võ Văn Tần, Q3, TP.HCM', '0966111222'),
(N'Công ty Huawei', N'33 Nguyễn Đình Chiểu, Q1, TP.HCM', '0977333444'),
(N'Công ty OnePlus', N'44 Lê Văn Sỹ, Q3, TP.HCM', '0988444555');

-- Thêm dữ liệu mẫu cho bảng Sản phẩm (24 dòng)
INSERT INTO SanPham (TenSP, DonGia, SoLuong, MaNCC) VALUES
(N'Galaxy S24', 20000000, 10, 1),
(N'Galaxy A55', 8000000, 20, 1),
(N'iPhone 15 Pro', 28000000, 8, 2),
(N'iPhone 13', 16000000, 15, 2),
(N'Xiaomi 14', 12000000, 12, 3),
(N'Xiaomi Redmi Note 13', 6000000, 25, 3),
(N'Oppo Find X5', 15000000, 10, 4),
(N'Oppo Reno8', 9000000, 18, 4),
(N'Vivo V29', 11000000, 14, 5),
(N'Vivo Y36', 5000000, 22, 5),
(N'Realme 11 Pro', 9000000, 16, 6),
(N'Realme C55', 4000000, 30, 6),
(N'Nokia X30', 8000000, 10, 7),
(N'Nokia G22', 3500000, 20, 7),
(N'Sony Xperia 1 V', 25000000, 5, 8),
(N'Sony Xperia 10 IV', 12000000, 8, 8),
(N'Asus ROG Phone 7', 23000000, 7, 9),
(N'Asus Zenfone 10', 15000000, 9, 9),
(N'Lenovo Legion Y90', 18000000, 6, 10),
(N'Lenovo K14 Plus', 4000000, 15, 10),
(N'Huawei P60 Pro', 21000000, 8, 11),
(N'Huawei Nova 11i', 7000000, 18, 11),
(N'OnePlus 11', 17000000, 10, 12),
(N'OnePlus Nord CE 3', 8000000, 20, 12);
```

## Cấu hình kết nối CSDL
- Chuỗi kết nối được cấu hình tại file `app.config`:
```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Server=localhost\SQLEXPRESS;Database=QLCuaHangDienThoai;Trusted_Connection=True;TrustServerCertificate=True;" />
</connectionStrings>
```
- Để thay đổi server/database, chỉ cần sửa file `app.config`.

## Hướng dẫn sử dụng
1. Tạo database và các bảng theo script trên trong SQL Server.
2. Chạy script dữ liệu mẫu để có sẵn dữ liệu nhà cung cấp và sản phẩm.
3. Build và chạy project.
4. Sử dụng các chức năng trên MainForm:
   - Quản lý Nhà cung cấp
   - Quản lý Sản phẩm
   - Bán hàng
   - Thống kê doanh thu

## Đóng góp & phát triển
- Có thể mở rộng thêm các chức năng như quản lý khách hàng, phân quyền, xuất báo cáo...
- Đóng góp qua pull request hoặc liên hệ tác giả.

---
**Lưu ý:**
- Ứng dụng sử dụng font Segoe UI để hỗ trợ tiếng Việt.
- Đảm bảo SQL Server đã bật chế độ TCP/IP và cho phép kết nối từ ứng dụng.
