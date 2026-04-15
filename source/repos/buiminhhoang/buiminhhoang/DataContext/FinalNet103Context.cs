using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using buiminhhoang.Models;

namespace buiminhhoang.DataContext;

public partial class FinalNet103Context : DbContext
{
    public FinalNet103Context()
    {
    }

    public FinalNet103Context(DbContextOptions<FinalNet103Context> options)
        : base(options)
    {
    }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MHDAYY;Database=FinalNet103;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhachHan__3214EC2712DC6545");

            entity.ToTable("KhachHang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MaLoaiKhach)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(100);

            entity.HasOne(d => d.MaLoaiKhachNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaLoaiKhach)
                .HasConstraintName("FK_KhachHang_LoaiKhachHang");
        });

        modelBuilder.Entity<LoaiKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiKhac__730A575932D5AB49");

            entity.ToTable("LoaiKhachHang");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
