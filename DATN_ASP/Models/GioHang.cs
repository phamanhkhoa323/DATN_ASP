using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
//using DATN_ASP.Areas.Identity.Data;

namespace DATN_ASP.Models
{
    public class GioHang
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        [DisplayName("Khách hàng")]
        public Users Users { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }
        
        public int SanPhamId { get; set; }
        [DisplayName("Tên sản phẩm")]
        public SanPham SanPham { get; set; }
        [DisplayName("Đơn giá")]
        public float DonGia { get; set; }
        [DisplayName("Số lượng")]
        [DefaultValue(1)]
        public int SoLuong { get; set; } = 1;
        [DisplayName("Thành tiền")]
        public float ThanhTien { get; set; }
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;
    }
}
