using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class NhaCungCap
    {
        public NhaCungCap()
        {
            HoaDonNhap = new HashSet<HoaDonNhap>();
        }

        [Key]
        public int IDNhaCungCap { get; set; }
        public string Ten { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public bool Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
    }
}