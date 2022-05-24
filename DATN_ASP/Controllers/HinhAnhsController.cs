using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN_ASP.Data;
using DATN_ASP.Models;

namespace DATN_ASP.Controllers
{
    public class HinhAnhsController : Controller
    {
        private readonly DATN_ASPContext _context;

        public HinhAnhsController(DATN_ASPContext context)
        {
            _context = context;
        }

        // GET: HinhAnhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HinhAnhs.ToListAsync());
        }

        // GET: HinhAnhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hinhAnh == null)
            {
                return NotFound();
            }

            return View(hinhAnh);
        }

        // GET: HinhAnhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HinhAnhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FileName,MaSP,NgayLap,TrangThai")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhAnh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnhs.FindAsync(id);
            if (hinhAnh == null)
            {
                return NotFound();
            }
            return View(hinhAnh);
        }

        // POST: HinhAnhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName,MaSP,NgayLap,TrangThai")] HinhAnh hinhAnh)
        {
            if (id != hinhAnh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhAnh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhAnhExists(hinhAnh.Id))
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
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hinhAnh == null)
            {
                return NotFound();
            }

            return View(hinhAnh);
        }

        // POST: HinhAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hinhAnh = await _context.HinhAnhs.FindAsync(id);
            _context.HinhAnhs.Remove(hinhAnh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhAnhExists(int id)
        {
            return _context.HinhAnhs.Any(e => e.Id == id);
        }
    }
}
