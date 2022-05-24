using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DATN_ASP.Models;

namespace DATN_ASP.Data
{
    public class DATN_ASPContext : DbContext
    {
        public DATN_ASPContext (DbContextOptions<DATN_ASPContext> options)
            : base(options)
        {
        }

        public DbSet<DATN_ASP.Models.Users> Users { get; set; }
        public DbSet<DATN_ASP.Models.GioHang> GioHangs { get; set; }
        public DbSet<DATN_ASP.Models.BinhLuan> BinhLuans { get; set; }
        public DbSet<DATN_ASP.Models.Banner> Banners { get; set; }
        public DbSet<DATN_ASP.Models.ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<DATN_ASP.Models.DanhMuc> DanhMucs { get; set; }
        public DbSet<DATN_ASP.Models.HinhAnh> HinhAnhs { get; set; }
        public DbSet<DATN_ASP.Models.HoaDon> HoaDons { get; set; }
        public DbSet<DATN_ASP.Models.SanPham> SanPhams { get; set; }
        public DbSet<DATN_ASP.Models.TacGia> TacGias { get; set; }
        public DbSet<DATN_ASP.Models.TacGiaSanPham> TacGiaSanPhams { get; set; }
        public DbSet<DATN_ASP.Models.ThongBao> ThongBaos { get; set; }
        public DbSet<DATN_ASP.Models.TinTuc> TinTucs { get; set; }
        public DbSet<DATN_ASP.Models.KhuyenMai> KhuyenMais{ get; set; }
        public DbSet<DATN_ASP.Models.NhaXuatBan> NhaXuatBans { get; set; }
    }
}
