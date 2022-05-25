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
    public class TacGiasController : Controller
    {
        private readonly DATN_ASPContext _context;

        public TacGiasController(DATN_ASPContext context)
        {
            _context = context;
        }

        // GET: Admin/TacGias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TacGias.ToListAsync());
        }

        // GET: Admin/TacGias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // GET: Admin/TacGias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TacGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenTacGia,Email,NgayLap,TrangThai")] TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tacGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tacGia);
        }

        // GET: Admin/TacGias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGias.FindAsync(id);
            if (tacGia == null)
            {
                return NotFound();
            }
            return View(tacGia);
        }

        // POST: Admin/TacGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenTacGia,Email,NgayLap,TrangThai")] TacGia tacGia)
        {
            if (id != tacGia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tacGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacGiaExists(tacGia.Id))
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
            return View(tacGia);
        }

        // GET: Admin/TacGias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacGia = await _context.TacGias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tacGia == null)
            {
                return NotFound();
            }

            return View(tacGia);
        }

        // POST: Admin/TacGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tacGia = await _context.TacGias.FindAsync(id);
            _context.TacGias.Remove(tacGia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacGiaExists(int id)
        {
            return _context.TacGias.Any(e => e.Id == id);
        }
    }
}
