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
    public class BinhLuan
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        [DisplayName("Người viết")]
        public Users Users { get; set; }
        public int SanPhamId { get; set; }
        [DisplayName("Mã sản phẩm")]
        public SanPham SanPham { get; set; }
        [DisplayName("Nội dung")]
        public string Noidung { get; set; }
        [DisplayName("Ngày viết")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool Status { get; set; } = true;
    }
}

