using System;
using System.Collections.Generic;
using DuAnBanGiay.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAnBanGiay.DataContext;

public partial class QlBanGiayFinalContext : DbContext
{
    public QlBanGiayFinalContext()
    {
    }

    public QlBanGiayFinalContext(DbContextOptions<QlBanGiayFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChatLieu> ChatLieus { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<CtspKm> CtspKms { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<Mau> Maus { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<KichThuoc> Sizes { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MHDAYY;Database=QL_BanGiay_Final;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__ChatLieu__453995BCE00DB632");

            entity.ToTable("ChatLieu");

            entity.Property(e => e.TenChatLieu).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaCtsp).HasName("PK__ChiTietS__1E4FCECDF61FD69C");

            entity.ToTable("ChiTietSanPham");

            entity.HasIndex(e => new { e.MaSanPham, e.MaMau, e.MaKichThuoc }, "UQ_SKU").IsUnique();

            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");
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

        modelBuilder.Entity<CtspKm>(entity =>
        {
            entity.HasKey(e => new { e.MaCtsp, e.MaKhuyenMai }).HasName("PK__CTSP_KM__D8BAA5F66E01C855");

            entity.ToTable("CTSP_KM");

            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");

            entity.HasOne(d => d.MaCtspNavigation).WithMany(p => p.CtspKms)
                .HasForeignKey(d => d.MaCtsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTSP_KM__MaCTSP__52593CB8");

            entity.HasOne(d => d.MaKhuyenMaiNavigation).WithMany(p => p.CtspKms)
                .HasForeignKey(d => d.MaKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTSP_KM__MaKhuye__534D60F1");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13BA21D41F6");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(0);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__HoaDon__MaKH__5CD6CB2B");

            entity.HasOne(d => d.MaVoucherNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaVoucher)
                .HasConstraintName("FK__HoaDon__MaVouche__5DCAEF64");
        });

        modelBuilder.Entity<HoaDonChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaHdct).HasName("PK__HoaDonCh__1419C1292D6BDD3A");

            entity.ToTable("HoaDonChiTiet");

            entity.Property(e => e.MaHdct).HasColumnName("MaHDCT");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaCtspNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaCtsp)
                .HasConstraintName("FK__HoaDonChi__MaCTS__619B8048");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__HoaDonChi__MaHoa__60A75C0F");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1EE06BECF8");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenKhachHang).HasMaxLength(200);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai).HasName("PK__KhuyenMa__6F56B3BD40F31753");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.GiaTriGiam).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(200);
        });

        modelBuilder.Entity<Mau>(entity =>
        {
            entity.HasKey(e => e.MaMau).HasName("PK__Mau__3A5BBB7D6D1A3B72");

            entity.ToTable("Mau");

            entity.Property(e => e.TenMau).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB7C98CAB2");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D1934BF37");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");
            entity.Property(e => e.TrangThai).HasDefaultValue(1);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK__SanPham__MaChatL__46E78A0C");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__SanPham__MaNCC__45F365D3");

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaTheLoai)
                .HasConstraintName("FK__SanPham__MaTheLo__44FF419A");

            entity.HasOne(d => d.MaThuongHieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaThuongHieu)
                .HasConstraintName("FK__SanPham__MaThuon__440B1D61");
        });

        modelBuilder.Entity<KichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__Size__22BFD6648538D43C");

            entity.ToTable("Size");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34A1F10D8F0");

            entity.ToTable("TheLoai");

            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaThuongHieu).HasName("PK__ThuongHi__A3733E2CD0AF20B2");

            entity.ToTable("ThuongHieu");

            entity.Property(e => e.TenThuongHieu).HasMaxLength(100);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.MaVoucher).HasName("PK__Voucher__0AAC5B116E8472CA");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.MaCode, "UQ__Voucher__152C7C5C1C5F2854").IsUnique();

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
