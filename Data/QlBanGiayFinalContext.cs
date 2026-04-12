using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WinFormsDashboard.Data.Models;

namespace WinFormsDashboard.Data;

public partial class QlBanGiayFinalContext : DbContext
{
    public QlBanGiayFinalContext()
    {
    }

    public QlBanGiayFinalContext(DbContextOptions<QlBanGiayFinalContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4Q61549\\SQLEXPRESS03;Database=QL_BanGiay_Final;Integrated Security=True;TrustServerCertificate=True;");

    public virtual DbSet<CTSP_KM> CTSP_KMs { get; set; }

    public virtual DbSet<ChatLieu> ChatLieus { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<Mau> Maus { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<Models.Size> Sizes { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CTSP_KM>(entity =>
        {
            entity.HasKey(e => new { e.MaCTSP, e.MaKhuyenMai }).HasName("PK__CTSP_KM__D8BAA5F65BCDD99D");

            entity.ToTable("CTSP_KM");

            entity.HasOne(d => d.MaCTSPNavigation).WithMany(p => p.CTSP_KMs)
                .HasForeignKey(d => d.MaCTSP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTSP_KM__MaCTSP__52593CB8");

            entity.HasOne(d => d.MaKhuyenMaiNavigation).WithMany(p => p.CTSP_KMs)
                .HasForeignKey(d => d.MaKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTSP_KM__MaKhuye__534D60F1");
        });

        modelBuilder.Entity<ChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__ChatLieu__453995BC0AA66B5E");

            entity.ToTable("ChatLieu");

            entity.Property(e => e.TenChatLieu).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaCTSP).HasName("PK__ChiTietS__1E4FCECD243E1BBE");

            entity.ToTable("ChiTietSanPham");

            entity.HasIndex(e => new { e.MaSanPham, e.MaMau, e.MaKichThuoc }, "UQ_SKU").IsUnique();

            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(1);

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaKic__4D94879B");

            entity.HasOne(d => d.MaMauNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaMau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaMau__4CA06362");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSa__MaSan__4BAC3F29");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13BD3DF3B0C");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(0);

            entity.HasOne(d => d.MaKHNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKH)
                .HasConstraintName("FK__HoaDon__MaKH__5CD6CB2B");

            entity.HasOne(d => d.MaVoucherNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaVoucher)
                .HasConstraintName("FK__HoaDon__MaVouche__5DCAEF64");
        });

        modelBuilder.Entity<HoaDonChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaHDCT).HasName("PK__HoaDonCh__1419C12992A2AE1E");

            entity.ToTable("HoaDonChiTiet");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaCTSPNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaCTSP)
                .HasConstraintName("FK__HoaDonChi__MaCTS__619B8048");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__HoaDonChi__MaHoa__60A75C0F");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKH).HasName("PK__KhachHan__2725CF1EC44FE936");

            entity.ToTable("KhachHang");

            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenKhachHang).HasMaxLength(200);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai).HasName("PK__KhuyenMa__6F56B3BD65C63712");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.GiaTriGiam).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(200);
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.MaMau).HasName("PK__Mau__3A5BBB7D338B7F52");

            entity.ToTable("Mau");

            entity.Property(e => e.TenMau).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNCC).HasName("PK__NhaCungC__3A185DEB10173631");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.TenNCC).HasMaxLength(100);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D0C8D567C");

            entity.ToTable("SanPham");

            entity.Property(e => e.TenSP).HasMaxLength(200);
            entity.Property(e => e.TrangThai).HasDefaultValue(1);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK__SanPham__MaChatL__46E78A0C");

            entity.HasOne(d => d.MaNCCNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNCC)
                .HasConstraintName("FK__SanPham__MaNCC__45F365D3");

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaTheLoai)
                .HasConstraintName("FK__SanPham__MaTheLo__44FF419A");

            entity.HasOne(d => d.MaThuongHieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaThuongHieu)
                .HasConstraintName("FK__SanPham__MaThuon__440B1D61");
        });

        modelBuilder.Entity<Models.Size>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__Size__22BFD66485B45A36");

            entity.ToTable("Size");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34A4646D9B3");

            entity.ToTable("TheLoai");

            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaThuongHieu).HasName("PK__ThuongHi__A3733E2C849C3732");

            entity.ToTable("ThuongHieu");

            entity.Property(e => e.TenThuongHieu).HasMaxLength(100);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.MaVoucher).HasName("PK__Voucher__0AAC5B11F14FF139");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.MaCode, "UQ__Voucher__152C7C5C3C953111").IsUnique();

            entity.Property(e => e.DieuKienGiam).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoTienGiam).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
