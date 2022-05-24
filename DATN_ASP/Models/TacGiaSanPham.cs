using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DATN_ASP.Models
{
    public class TacGiaSanPham
    {
        public int Id { get; set; }
        public int SanPhamId { get; set; }
        public int TacGiaId { get; set; }
        public TacGia TacGia { get; set; }
    }
}
