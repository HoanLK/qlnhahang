using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class HoaDonXuat
    {
        public HoaDonXuat()
        {
            ChiTietHoaDonXuat = new HashSet<ChiTietHoaDonXuat>();
        }

        [Key]
        public int IDHoaDonXuat { get; set; }
        public int IDNhanVien { get; set; }
        public DateTime ThoiGian { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTietHoaDonXuat> ChiTietHoaDonXuat { get; set; }
    }
}