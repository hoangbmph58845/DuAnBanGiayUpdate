CREATE DATABASE QL_BanGiay_Final
GO
USE QL_BanGiay_Final
GO

/* ================= DANH MỤC ================= */

CREATE TABLE ThuongHieu(
    MaThuongHieu INT IDENTITY PRIMARY KEY,
    TenThuongHieu NVARCHAR(100) NOT NULL
)

INSERT INTO ThuongHieu VALUES
(N'Nike'),(N'Adidas'),(N'Puma'),(N'Converse'),(N'Vans')


CREATE TABLE TheLoai(
    MaTheLoai INT IDENTITY PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL
)

INSERT INTO TheLoai VALUES
(N'Sneaker'),(N'Running'),(N'Football'),(N'Street'),(N'Fashion')


CREATE TABLE NhaCungCap(
    MaNCC INT IDENTITY PRIMARY KEY,
    TenNCC NVARCHAR(100) NOT NULL
)

INSERT INTO NhaCungCap VALUES
(N'NCC Hà Nội'),(N'NCC HCM'),(N'NCC Đà Nẵng'),(N'NCC Hải Phòng'),(N'NCC Cần Thơ')


CREATE TABLE ChatLieu(
    MaChatLieu INT IDENTITY PRIMARY KEY,
    TenChatLieu NVARCHAR(100) NOT NULL
)

INSERT INTO ChatLieu VALUES
(N'Da'),(N'Vải'),(N'Lưới'),(N'Cao su'),(N'Tổng hợp')


CREATE TABLE Mau(
    MaMau INT IDENTITY PRIMARY KEY,
    TenMau NVARCHAR(50) NOT NULL
)

INSERT INTO Mau VALUES
(N'Đen'),(N'Trắng'),(N'Xanh'),(N'Đỏ'),(N'Xám')


CREATE TABLE Size(
    MaKichThuoc INT IDENTITY PRIMARY KEY,
    SoSize INT NOT NULL
)

INSERT INTO Size VALUES (38),(39),(40),(41),(42)


/* ================= SẢN PHẨM ================= */

CREATE TABLE SanPham(
    MaSanPham INT IDENTITY PRIMARY KEY,
    TenSP NVARCHAR(200) NOT NULL,
    MaThuongHieu INT,
    MaTheLoai INT,
    MaNCC INT,
    MaChatLieu INT,
    TrangThai INT DEFAULT 1,

    FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu,
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap,
    FOREIGN KEY (MaChatLieu) REFERENCES ChatLieu
)

INSERT INTO SanPham VALUES
(N'Nike Air Force 1',1,1,1,2,1),
(N'Adidas Ultraboost',2,2,2,3,1),
(N'Puma Future Rider',3,4,3,5,1),
(N'Converse Classic',4,5,4,2,1),
(N'Vans Old Skool',5,4,5,2,1)


/* ================= BIẾN THỂ SKU ================= */

CREATE TABLE ChiTietSanPham(
    MaCTSP INT IDENTITY PRIMARY KEY,
    MaSanPham INT NOT NULL,
    MaMau INT NOT NULL,
    MaKichThuoc INT NOT NULL,
    GiaNhap DECIMAL(18,2) NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongTon INT NOT NULL,
    TrangThai INT DEFAULT 1,

    CONSTRAINT UQ_SKU UNIQUE (MaSanPham, MaMau, MaKichThuoc),

    FOREIGN KEY (MaSanPham) REFERENCES SanPham,
    FOREIGN KEY (MaMau) REFERENCES Mau,
    FOREIGN KEY (MaKichThuoc) REFERENCES Size
)

/* 25 BIẾN THỂ */
INSERT INTO ChiTietSanPham VALUES
(1,1,1,1500000,2500000,10,1),
(1,1,2,1500000,2500000,9,1),
(1,2,3,1500000,2500000,8,1),
(1,2,4,1500000,2500000,7,1),
(1,3,5,1500000,2500000,6,1),

(2,2,1,2000000,3200000,12,1),
(2,2,2,2000000,3200000,11,1),
(2,3,3,2000000,3200000,10,1),
(2,3,4,2000000,3200000,9,1),
(2,4,5,2000000,3200000,8,1),

(3,1,1,1300000,2100000,15,1),
(3,1,2,1300000,2100000,14,1),
(3,2,3,1300000,2100000,13,1),
(3,2,4,1300000,2100000,12,1),
(3,3,5,1300000,2100000,11,1),

(4,3,1,1000000,1800000,10,1),
(4,3,2,1000000,1800000,9,1),
(4,4,3,1000000,1800000,8,1),
(4,4,4,1000000,1800000,7,1),
(4,5,5,1000000,1800000,6,1),

(5,1,1,1200000,2000000,12,1),
(5,1,2,1200000,2000000,11,1),
(5,2,3,1200000,2000000,10,1),
(5,2,4,1200000,2000000,9,1),
(5,3,5,1200000,2000000,8,1)


/* ================= KHUYẾN MÃI ================= */

CREATE TABLE KhuyenMai(
    MaKhuyenMai INT IDENTITY PRIMARY KEY,
    TenKhuyenMai NVARCHAR(200),
    LoaiGiam INT, -- 1 % , 2 tiền
    GiaTriGiam DECIMAL(18,2),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    TrangThai INT
)

INSERT INTO KhuyenMai VALUES
(N'Sale 10%',1,10,'2026-03-01','2026-04-01',1),
(N'Sale 200K',2,200000,'2026-03-01','2026-04-01',1),
(N'Sale 15%',1,15,'2026-03-01','2026-04-01',1),
(N'Sale 300K',2,300000,'2026-03-01','2026-04-01',1),
(N'Sale 5%',1,5,'2026-03-01','2026-04-01',1)


CREATE TABLE CTSP_KM(
    MaCTSP INT,
    MaKhuyenMai INT,
    TrangThai INT,
    PRIMARY KEY (MaCTSP,MaKhuyenMai),
    FOREIGN KEY (MaCTSP) REFERENCES ChiTietSanPham,
    FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai
)

INSERT INTO CTSP_KM VALUES
(1,1,1),(6,2,1),(11,3,1),(16,4,1),(21,5,1)


/* ================= VOUCHER ================= */

CREATE TABLE Voucher(
    MaVoucher INT IDENTITY PRIMARY KEY,
    MaCode VARCHAR(50) UNIQUE,
    SoTienGiam DECIMAL(18,2),
    DieuKienGiam DECIMAL(18,2),
    TrangThai INT
)

INSERT INTO Voucher VALUES
('VC100',100000,1000000,1),
('VC150',150000,1500000,1),
('VC200',200000,2000000,1),
('VC250',250000,2500000,1),
('VC300',300000,3000000,1)


/* ================= KHÁCH HÀNG ================= */

CREATE TABLE KhachHang(
    MaKH INT IDENTITY PRIMARY KEY,
    TenKhachHang NVARCHAR(200),
    SoDienThoai VARCHAR(20)
)

INSERT INTO KhachHang VALUES
(N'Nguyễn Văn A','0900000001'),
(N'Trần Văn B','0900000002'),
(N'Lê Văn C','0900000003'),
(N'Phạm Văn D','0900000004'),
(N'Hoàng Văn E','0900000005')


/* ================= HÓA ĐƠN ================= */

CREATE TABLE HoaDon(
    MaHoaDon INT IDENTITY PRIMARY KEY,
    MaKH INT NULL,
    MaVoucher INT NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2),
    TrangThai INT DEFAULT 0,
    -- 0 hóa đơn chờ
    -- 1 đã thanh toán
    -- 2 đã hủy

    FOREIGN KEY (MaKH) REFERENCES KhachHang,
    FOREIGN KEY (MaVoucher) REFERENCES Voucher
)

INSERT INTO HoaDon(TongTien,TrangThai,MaKH,MaVoucher) VALUES
(2500000,1,1,1),
(3200000,1,2,2),
(2100000,0,3,NULL),
(1800000,1,4,3),
(2000000,2,5,NULL)


/* ================= HÓA ĐƠN CHI TIẾT ================= */

CREATE TABLE HoaDonChiTiet(
    MaHDCT INT IDENTITY PRIMARY KEY,
    MaHoaDon INT,
    MaCTSP INT,
    SoLuong INT,
    DonGia DECIMAL(18,2),
    ThanhTien DECIMAL(18,2),

    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon,
    FOREIGN KEY (MaCTSP) REFERENCES ChiTietSanPham
)

INSERT INTO HoaDonChiTiet VALUES
(1,1,1,2500000,2500000),
(2,6,1,3200000,3200000),
(4,11,1,1800000,1800000)
GO