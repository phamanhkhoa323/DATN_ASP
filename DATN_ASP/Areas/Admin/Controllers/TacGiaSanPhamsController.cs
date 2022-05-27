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
    public class TacGiaSanPhamsController : Controller
    {
        private readonly DATN_ASPContext _context;

        public TacGiaSanPhamsController(DATN_ASPContext context)
        {
            _context = context;
        }

        // GET: Admin/TacGiaSanPhams
        public async Task<IActionResult> Index()
        {
            var dATN_ASPContext = _context.TacGiaSanPhams.Include(t => t.TacGia);
            return View(await dATN_ASPContext.ToListAsync());
        }

        // GET: Admin/TacGiaSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGiaSanPham = await _context.TacGiaSanPhams
                .Include(t => t.TacGia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tacGiaSanPham == null)
            {
                return NotFound();
            }

            return View(tacGiaSanPham);
        }

        // GET: Admin/TacGiaSanPhams/Create
        public IActionResult Create()
        {
            ViewData["TacGiaId"] = new SelectList(_context.TacGias, "Id", "Id");
            return View();
        }

        // POST: Admin/TacGiaSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SanPhamId,TacGiaId")] TacGiaSanPham tacGiaSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacGiaSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TacGiaId"] = new SelectList(_context.TacGias, "Id", "Id", tacGiaSanPham.TacGiaId);
            return View(tacGiaSanPham);
        }

        // GET: Admin/TacGiaSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGiaSanPham = await _context.TacGiaSanPhams.FindAsync(id);
            if (tacGiaSanPham == null)
            {
                return NotFound();
            }
            ViewData["TacGiaId"] = new SelectList(_context.TacGias, "Id", "Id", tacGiaSanPham.TacGiaId);
            return View(tacGiaSanPham);
        }

        // POST: Admin/TacGiaSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SanPhamId,TacGiaId")] TacGiaSanPham tacGiaSanPham)
        {
            if (id != tacGiaSanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tacGiaSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacGiaSanPhamExists(tacGiaSanPham.Id))
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
            ViewData["TacGiaId"] = new SelectList(_context.TacGias, "Id", "Id", tacGiaSanPham.TacGiaId);
            return View(tacGiaSanPham);
        }

        // GET: Admin/TacGiaSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGiaSanPham = await _context.TacGiaSanPhams
                .Include(t => t.TacGia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tacGiaSanPham == null)
            {
                return NotFound();
            }

            return View(tacGiaSanPham);
        }

        // POST: Admin/TacGiaSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tacGiaSanPham = await _context.TacGiaSanPhams.FindAsync(id);
            _context.TacGiaSanPhams.Remove(tacGiaSanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacGiaSanPhamExists(int id)
        {
            return _context.TacGiaSanPhams.Any(e => e.Id == id);
        }
    }
}
