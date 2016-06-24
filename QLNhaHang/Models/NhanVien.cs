using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class NhanVien
    {
        public NhanVien()
        {
            HoaDonNhap = new HashSet<HoaDonNhap>();
            HoaDonXuat = new HashSet<HoaDonXuat>();
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        [Key]
        public int IDNhanVien { get; set; }
        public int IDNhomNhanVien { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual NhomNhanVien NhomNhanVien { get; set; }
        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual ICollection<HoaDonXuat> HoaDonXuat { get; set; }
    }
}