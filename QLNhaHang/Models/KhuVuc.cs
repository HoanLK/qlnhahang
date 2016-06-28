using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class KhuVuc
    {
        public KhuVuc()
        {
            Ban = new HashSet<Ban>();
        }

        [Key]
        public int IDKhuVuc { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Ban> Ban { get; set; }
    }
}