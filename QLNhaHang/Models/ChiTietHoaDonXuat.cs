using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class ChiTietHoaDonXuat
    {
        [Key]
        public int IDChiTietHoaDonXuat { get; set; }
        public int IDHoaDonXuat { get; set; }
        public int IDMatHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual MatHang MatHang { get; set; }
        public virtual HoaDonXuat HoaDonXuat { get; set; }
    }
}