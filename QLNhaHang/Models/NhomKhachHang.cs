using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class NhomKhachHang
    {
        public NhomKhachHang()
        {
            KhachHang = new HashSet<KhachHang>();
        }

        [Key]
        public int IDNhomKhachHang { get; set; }
        public string Ten { get; set; }
        public float DoanhSo { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
}