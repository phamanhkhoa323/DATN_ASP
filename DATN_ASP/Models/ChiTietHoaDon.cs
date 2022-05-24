using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DATN_ASP.Models
{
    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int HoaDonId { get; set; }
        [DisplayName("Mã hóa đơn")]
        public HoaDon HoaDon { get; set; }
        
        public int SanPhamId { get; set; }
        [DisplayName("Mã sản phẩm")]
        public SanPham SanPham { get; set; }
        [DisplayName("Đơn giá")]
        public float DonGia { get; set; }
        [DisplayName("Số lượng")]
        [DefaultValue(1)]
        public int SoLuong { get; set; } = 1;
        [DisplayName("Thành tiền")]
        public float ThanhTien { get; set; }
    }
}
