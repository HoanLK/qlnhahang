using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class PhieuThu
    {
        [Key]
        public int IDPhieuThu { get; set; }
        public int IdLyDoThu { get; set; }
        public DateTime ThoiGian { get; set; }
        public int SoTien { get; set; }
        public string ChungTuKeoTheo { get; set; }
        public string NguoiNop { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual LyDoThu LyDoThu { get; set; }
    }
}