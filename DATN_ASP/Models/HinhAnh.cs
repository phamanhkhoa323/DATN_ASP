using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DATN_ASP.Models
{
    public class HinhAnh
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        [DisplayName("Trạng thái")]
        [DefaultValue(true)]
        public bool TrangThai { get; set; } = true;
    }
}
