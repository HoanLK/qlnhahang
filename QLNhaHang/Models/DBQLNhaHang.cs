using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class DBQLNhaHang: DbContext
    {
        public DBQLNhaHang(): base("name = DBQLNhaHang") { }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<ChiTietHoaDonBanHang> ChiTietHoaDonBanHangs { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual DbSet<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
        public virtual DbSet<DinhLuong> DinhLuongs { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHangs { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuats { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<LyDoChi> LyDoChis { get; set; }
        public virtual DbSet<LyDoThu> LyDoThus { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomKhachHang> NhomKhachHangs { get; set; }
        public virtual DbSet<NhomMatHang> NhomMatHangs { get; set; }
        public virtual DbSet<NhomNhanVien> NhomNhanViens { get; set; }
        public virtual DbSet<NhomThucDon> NhomThucDons { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DonViTinh>()
                .HasOptional(a => a.MatHang)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<DonViTinh>()
                .HasOptional(a => a.ThucDon)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);
        }
    }
}