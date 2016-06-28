using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class DonViTinh
    {
        public DonViTinh()
        {
            ThucDon = new HashSet<ThucDon>();
            MatHang = new HashSet<MatHang>();
        }

        [Key]
        public int IDDonViTinh { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<ThucDon> ThucDon { get; set; }
        public virtual ICollection<MatHang> MatHang { get; set; }
    }
}