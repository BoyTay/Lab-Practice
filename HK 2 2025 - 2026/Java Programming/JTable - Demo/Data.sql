-- Tạo Database (nếu chưa có)
CREATE DATABASE QuanLyBanHang;
GO
USE QuanLyBanHang;
GO

-- Tạo bảng SanPham
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY,       -- Mã sản phẩm (Khóa chính)
    TenSP NVARCHAR(50) NOT NULL,        -- Tên sản phẩm (Hỗ trợ tiếng Việt)
    DVT NVARCHAR(20),                   -- Đơn vị tính (Chai, Thùng, Kg...)
    DonGia FLOAT,                       -- Đơn giá bán
    NhaCungCap NVARCHAR(50)             -- Nhà cung cấp
);

-- Thêm một vài dữ liệu mẫu
INSERT INTO SanPham VALUES ('SP01', N'Dầu gội đầu Head & S...', N'Chai', 34000, 'Unilevers');
INSERT INTO SanPham VALUES ('SP02', N'Xà bông Omo', N'Thùng', 124000, 'Unilevers');

select * from SanPham