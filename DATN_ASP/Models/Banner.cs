using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DATN_ASP.Models
{
    public class Banner
    {
        public int Id { get; set; }
        [DisplayName("Tên Banner")]
        public string TenBanner { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }
        
        public int TinTucId { get; set; }
        [DisplayName("Link bài viết")]
        public TinTuc TinTuc { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;
    }
}
