using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DATN_ASP.Models
{
    public class KhuyenMai
    {
        public int Id { get; set; }
        [DisplayName("Tên khuyến mãi")]
        public string TenKM { get; set; }
        [DisplayName("Mã khuyến mãi")]
        public string MaKM { get; set; }
        [DisplayName("Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [DisplayName("Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]

        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;
    }
}
