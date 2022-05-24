using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DATN_ASP.Models
{
    public class NhaXuatBan
    {
        public int Id { get; set; }
        [DisplayName("Mã NXB")]
        public string MaNXB { get; set; }
        [DisplayName("Nhà xuất bản")]
        public string TenNXB { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        public string Email { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;

        public List<SanPham> SanPhams { get; set; }

    }
}
