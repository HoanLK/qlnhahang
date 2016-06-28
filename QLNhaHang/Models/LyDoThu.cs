using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class LyDoThu
    {
        public LyDoThu()
        {
            PhieuThu = new HashSet<PhieuThu>();
        }

        [Key]
        public int IDLyDoThu { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public String GhiChu { get; set; }

        public virtual ICollection<PhieuThu> PhieuThu { get; set; }
    }
}