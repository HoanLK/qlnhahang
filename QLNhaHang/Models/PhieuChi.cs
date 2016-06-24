using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class PhieuChi
    {
        [Key]
        public int IDPhieuChi { get; set; }
        public int IDLyDoChi { get; set; }
        public DateTime ThioiGian { get; set; }
        public int SoTien { get; set; }
        public string ChungTuKemTheo { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual LyDoChi LyDoChi { get; set; }
    }
}