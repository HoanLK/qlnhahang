using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class LyDoChi
    {
        public LyDoChi()
        {
            PhieuChi = new HashSet<PhieuChi>();
        }

        [Key]
        public string IDLyDoChi { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<PhieuChi> PhieuChi { get; set; }
    }
}