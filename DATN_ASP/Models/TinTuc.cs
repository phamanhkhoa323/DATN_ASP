using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using DATN_ASP.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace DATN_ASP.Models
{
    public class TinTuc
    {
        public int Id { get; set; }
        [DisplayName("Tiêu đề")]
        public string TieuDe { get; set; }
        
        public string UsersId { get; set; }
        [DisplayName("Người viết")]
        public Users Users { get; set; }
        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }
        public string Link { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }
        [DisplayName("Ngày viết")]
        [DataType(DataType.Date)]
        public DateTime NgayViet { get; set; } = DateTime.Now;

        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;

        public List<Banner> Banners { get; set; }

    }
}


