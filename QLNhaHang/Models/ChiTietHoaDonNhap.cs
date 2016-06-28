using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class ChiTietHoaDonNhap
    {
        [Key]
        public int IDChiTietHoaDonNhap { get; set; }
        public int IDHoaDonNhap { get; set; }
        public int IDMatHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }
        public virtual MatHang MatHang { get; set; }
    }
}