-- Căn chỉnh schema theo ERD: SanPham.NhaCungCap, SanPham.ChatLieu; ChiTietSanPham không còn GiaNhap.
-- Chạy trên database QL_BanGiay_Final (hoặc đổi USE).

USE QL_BanGiay_Final;
GO

IF COL_LENGTH('dbo.SanPham', 'MaNCC') IS NOT NULL
    EXEC sp_rename 'dbo.SanPham.MaNCC', 'NhaCungCap', 'COLUMN';
GO

IF COL_LENGTH('dbo.SanPham', 'MaChatLieu') IS NOT NULL
    EXEC sp_rename 'dbo.SanPham.MaChatLieu', 'ChatLieu', 'COLUMN';
GO

IF COL_LENGTH('dbo.ChiTietSanPham', 'GiaNhap') IS NOT NULL
    ALTER TABLE dbo.ChiTietSanPham DROP COLUMN GiaNhap;
GO
