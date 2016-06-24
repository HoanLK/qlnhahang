using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class NhomNhanVien
    {
        public NhomNhanVien()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        [Key]
        public int IDNhomNhanVien { get; set; }
        public string TenNhom { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}