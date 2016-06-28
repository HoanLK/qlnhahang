using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhap = new HashSet<ChiTietHoaDonNhap>();
        }

        [Key]
        public int IDHoaDonNhap { get; set; }
        public int IDNhanVien { get; set; }
        public int IDNhaCungCap { get; set; }
        public DateTime ThoiGian { get; set; }
        public float TongTien { get; set; }
        public float GiamGia { get; set; }
        public float TongTienSauGiamGia { get; set; }
        public float TraTruoc { get; set; }
        public DateTime ThoiGianHenTra { get; set; }
        public float TienConLai { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}