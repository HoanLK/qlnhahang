using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class ChiTietHoaDonBanHang
    {


        [Key]
        public int IDChiTietHoaDonBanHang { get; set; }
        public int IDHoaDonBanHang { get; set; }
        public int IDThucDon { get; set; }
        public int SoLuong { get; set; }
        public byte DaPhucVu { get; set; }
        public string GhiChu { get; set; }

        public virtual HoaDonBanHang HoaDonBanHang { get; set; }
        public virtual ThucDon ThucDon { get; set; }
    }
}