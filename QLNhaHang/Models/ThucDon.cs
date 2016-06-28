using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class ThucDon
    {
        public ThucDon()
        {
            ChiTietHoaDonBanHang = new HashSet<ChiTietHoaDonBanHang>();
            DinhLuong = new HashSet<DinhLuong>();
        }

        [Key]
        public int IDThucDon { get; set; }
        public int IDNhomThucDon { get; set; }
        public int IDDonViTinh { get; set; }
        public string Ten { get; set; }
        public float DonGia { get; set; }
        public string HinhAnh { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<ChiTietHoaDonBanHang> ChiTietHoaDonBanHang { get; set; }
        public virtual NhomThucDon NhomThucDon { get; set; }
        public virtual ICollection<DinhLuong> DinhLuong { get; set; }
        public virtual DonViTinh DonViTinh { get; set; }
    }
}