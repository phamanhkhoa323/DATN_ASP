﻿using DATN_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DATN_ASP.Data;
using Microsoft.EntityFrameworkCore;

namespace DATN_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DATN_ASPContext _context;

        public HomeController(ILogger<HomeController> logger, DATN_ASPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var sp = _context.SanPhams.ToList();
            return View(sp);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Cart")]
        public IActionResult Cart()
        {

            return View();
        }

        [Route("Checkout")]
        public IActionResult Checkout()
        {

            return View();
        }

        [Route("SanPham")]
        public IActionResult SanPham()
        {
            var sp = _context.SanPhams.ToList();
            return View(sp);
        }

        [Route("Detail")]
        public async Task<IActionResult> Detail(int? id)
        {
            var sp = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .Include(s => s.HinhAnh)
                .Include(s => s.KhuyenMai)
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(sp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
