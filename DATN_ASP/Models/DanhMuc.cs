using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DATN_ASP.Models
{
    public class DanhMuc
    {
        public int Id { get; set; }
        [DisplayName("Tên danh mục")]
        public string TenDM { get; set; }
        [DisplayName("Ngày lập")]
        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; } = DateTime.Now;
        
        public List<SanPham> SanPhams { get; set; }

    }
}
