using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN_ASP.Data;
using DATN_ASP.Models;

namespace DATN_ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly DATN_ASPContext _context;

        public SanPhamsController(DATN_ASPContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index()
        {
            var dATN_ASPContext = _context.SanPhams.Include(s => s.DanhMuc).Include(s => s.HinhAnh).Include(s => s.KhuyenMai).Include(s => s.NhaXuatBan);
            return View(await dATN_ASPContext.ToListAsync());
        }

        // GET: Admin/SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .Include(s => s.HinhAnh)
                .Include(s => s.KhuyenMai)
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id");
            ViewData["HinhAnhId"] = new SelectList(_context.HinhAnhs, "Id", "Id");
            ViewData["KhuyenMaiId"] = new SelectList(_context.KhuyenMais, "Id", "Id");
            ViewData["NhaXuatBanId"] = new SelectList(_context.NhaXuatBans, "Id", "Id");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnhDaiDien,HinhAnhId,MaSP,TenSP,DonGia,SoLuong,DanhMucId,TacGiaId,NhaXuatBanId,NgayXuatBan,MoTa,KhuyenMaiId,GiamGia,NgayLap,TrangThai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            ViewData["HinhAnhId"] = new SelectList(_context.HinhAnhs, "Id", "Id", sanPham.HinhAnhId);
            ViewData["KhuyenMaiId"] = new SelectList(_context.KhuyenMais, "Id", "Id", sanPham.KhuyenMaiId);
            ViewData["NhaXuatBanId"] = new SelectList(_context.NhaXuatBans, "Id", "Id", sanPham.NhaXuatBanId);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            ViewData["HinhAnhId"] = new SelectList(_context.HinhAnhs, "Id", "Id", sanPham.HinhAnhId);
            ViewData["KhuyenMaiId"] = new SelectList(_context.KhuyenMais, "Id", "Id", sanPham.KhuyenMaiId);
            ViewData["NhaXuatBanId"] = new SelectList(_context.NhaXuatBans, "Id", "Id", sanPham.NhaXuatBanId);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnhDaiDien,HinhAnhId,MaSP,TenSP,DonGia,SoLuong,DanhMucId,TacGiaId,NhaXuatBanId,NgayXuatBan,MoTa,KhuyenMaiId,GiamGia,NgayLap,TrangThai")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "Id", sanPham.DanhMucId);
            ViewData["HinhAnhId"] = new SelectList(_context.HinhAnhs, "Id", "Id", sanPham.HinhAnhId);
            ViewData["KhuyenMaiId"] = new SelectList(_context.KhuyenMais, "Id", "Id", sanPham.KhuyenMaiId);
            ViewData["NhaXuatBanId"] = new SelectList(_context.NhaXuatBans, "Id", "Id", sanPham.NhaXuatBanId);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.DanhMuc)
                .Include(s => s.HinhAnh)
                .Include(s => s.KhuyenMai)
                .Include(s => s.NhaXuatBan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
