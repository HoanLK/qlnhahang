using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class KhachHang
    {
        public KhachHang()
        {
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        [Key]
        public int IDKhachHang { get; set; }
        public int IDNhomKhachHang { get; set; }
        public string Ten { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual NhomKhachHang NhomKhachHang { get; set; }
    }
}