using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace DATN_ASP.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        public int HinhAnhId { get; set; }
        [DisplayName("Danh sách hình ảnh ")]
        public HinhAnh HinhAnh { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }

        [DisplayName("Đơn giá")]
        public float DonGia { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        public int DanhMucId { get; set; }
        [DisplayName("Danh mục")]
        public DanhMuc DanhMuc { get; set; }
        [DisplayName("Tác giả")]
        public int TacGiaId { get; set; } 
        
        
        public int NhaXuatBanId {get; set; }
        [DisplayName("Nhà xuất bản")]
        public NhaXuatBan NhaXuatBan { get; set; }
        [DisplayName("Ngày xuất bản")]
        [DataType(DataType.Date)]
        public DateTime NgayXuatBan { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
      
        public int KhuyenMaiId { get; set; }
        [DisplayName("Mã khuyến mãi")]
        public KhuyenMai KhuyenMai { get; set; }
        [DisplayName("Giảm giá")]
        public int GiamGia { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;

        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public List<GioHang> GioHangs { get; set; }
        public List<TacGiaSanPham> TacGiaSanPhams { get; set; }
        public List<BinhLuan> BinhLuans { get; set; }
    }
}
