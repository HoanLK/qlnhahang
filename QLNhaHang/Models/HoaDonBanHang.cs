using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNhaHang.Models
{
    public class HoaDonBanHang
    {
        public HoaDonBanHang()
        {
            ChiTietHoaDonBanHang = new HashSet<ChiTietHoaDonBanHang>();
        }

        [Key]
        public int IDHoaDonBanHang { get; set; }
        public int IDNhanVien { get; set; }
        public int IDKhachHang { get; set; }
        public int IDBan { get; set; }
        public DateTime ThoiGian { get; set; }
        public float TongTien { get; set; }
        public float ChietKhau { get; set; }
        public string DichVu { get; set; }
        public float VAT { get; set; }
        public float ThanhToan { get; set; }
        public byte Huy { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Ban Ban { get; set; }
        public virtual ICollection<ChiTietHoaDonBanHang> ChiTietHoaDonBanHang { get; set; }
    }
}