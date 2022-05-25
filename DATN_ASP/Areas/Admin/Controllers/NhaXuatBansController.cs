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
    public class NhaXuatBansController : Controller
    {
        private readonly DATN_ASPContext _context;

        public NhaXuatBansController(DATN_ASPContext context)
        {
            _context = context;
        }

        // GET: Admin/NhaXuatBans
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaXuatBans.ToListAsync());
        }

        // GET: Admin/NhaXuatBans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaXuatBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNXB,TenNXB,DiaChi,Email,NgayLap,TrangThai")] NhaXuatBan nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaXuatBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans.FindAsync(id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }
            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNXB,TenNXB,DiaChi,Email,NgayLap,TrangThai")] NhaXuatBan nhaXuatBan)
        {
            if (id != nhaXuatBan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaXuatBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaXuatBanExists(nhaXuatBan.Id))
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
            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaXuatBan = await _context.NhaXuatBans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaXuatBan == null)
            {
                return NotFound();
            }

            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaXuatBan = await _context.NhaXuatBans.FindAsync(id);
            _context.NhaXuatBans.Remove(nhaXuatBan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaXuatBanExists(int id)
        {
            return _context.NhaXuatBans.Any(e => e.Id == id);
        }
    }
}
