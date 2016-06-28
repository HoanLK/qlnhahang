using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class NhomThucDon
    {
        public NhomThucDon()
        {
            ThucDon = new HashSet<ThucDon>();
        }

        [Key]
        public int IDNhomThucDon { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<ThucDon> ThucDon { get; set; }
    }
}