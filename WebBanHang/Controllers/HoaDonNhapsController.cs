using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    
    public class HoaDonNhapsController : Controller
    {
        private readonly WebBanHangContext _context;

        public HoaDonNhapsController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: HoaDonNhaps
        public async Task<IActionResult> Index(string SearchString)
        {
            var webBanHangContext = _context.HoaDonNhap.Include(h => h.NhaCungCap).Where(m => m.MaHDN.Contains(SearchString) || SearchString == null);
            return View(await webBanHangContext.ToListAsync());
        }

        // GET: HoaDonNhaps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap
                .Include(h => h.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaHDN == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Create
        public IActionResult Create()
        {
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "TenNCC");
            return View();
        }

        // POST: HoaDonNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHDN,NgayNhap,MaNCC")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHDN,NgayNhap,MaNCC")] HoaDonNhap hoaDonNhap)
        {
            if (id != hoaDonNhap.MaHDN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapExists(hoaDonNhap.MaHDN))
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
            ViewData["MaNCC"] = new SelectList(_context.NhaCungCap, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap
                .Include(h => h.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaHDN == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDonNhap == null)
            {
                return Problem("Entity set 'WebBanHangContext.HoaDonNhap'  is null.");
            }
            var hoaDonNhap = await _context.HoaDonNhap.FindAsync(id);
            if (hoaDonNhap != null)
            {
                _context.HoaDonNhap.Remove(hoaDonNhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonNhapExists(string id)
        {
          return (_context.HoaDonNhap?.Any(e => e.MaHDN == id)).GetValueOrDefault();
        }
    }
}
