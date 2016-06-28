using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class MatHang
    {
        public MatHang()
        {
            ChiTietHoaDonXuat = new HashSet<ChiTietHoaDonXuat>();
            ChiTietHoaDonNhap = new HashSet<ChiTietHoaDonNhap>();
            DinhLuong = new HashSet<DinhLuong>();
        }

        [Key]
        public int IDMatHang { get; set; }
        public int IDNhomMatHang { get; set; }


        public int IDDonViTinh { get; set; }
        public string Ten { get; set; }
        public float DonGia { get; set; }
        public int TonToiThieu { get; set; }
        public int Ton { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }
        public virtual NhomMatHang NhomMatHang { get; set; }
        public virtual ICollection<ChiTietHoaDonXuat> ChiTietHoaDonXuat { get; set; }
        public virtual ICollection<DinhLuong> DinhLuong { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
    }
}