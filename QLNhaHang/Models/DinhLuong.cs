using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class DinhLuong
    {
        [Key]
        public int IDDinhLuong { get; set; }
        public int IDThucDon { get; set; }
        public int IDMatHang { get; set; } /*none*/
        public int SoLuong { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual ThucDon ThucDon { get; set; }
        public virtual MatHang MatHang { get; set; }
    }
}