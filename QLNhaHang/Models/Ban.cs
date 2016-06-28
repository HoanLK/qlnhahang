using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class Ban
    {
        public Ban()
        {
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        [Key]
        public int IDBan { get; set; }
        public int IDKhuVuc { get; set; }
        public string Ten { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual KhuVuc KhuVuc { get; set; }
    }
}