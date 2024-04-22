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
   
    public class ChiTietHDNsController : Controller
    {
        private readonly WebBanHangContext _context;

        public ChiTietHDNsController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: ChiTietHDNs
        public async Task<IActionResult> Index(string SearchString)
        {
            var webBanHangContext = _context.ChiTietHDN.Include(c => c.HoaDonNhap).Include(c => c.QuanAo).Where(m => m.MaHDN.Contains(SearchString) || SearchString == null);
            return View(await webBanHangContext.ToListAsync());
        }

        // GET: ChiTietHDNs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChiTietHDN == null)
            {
                return NotFound();
            }

            var chiTietHDN = await _context.ChiTietHDN
                .Include(c => c.HoaDonNhap)
                .Include(c => c.QuanAo)
                .FirstOrDefaultAsync(m => m.MaHDN == id);
            if (chiTietHDN == null)
            {
                return NotFound();
            }

            return View(chiTietHDN);
        }

        // GET: ChiTietHDNs/Create
        public IActionResult Create()
        {
            ViewData["MaHDN"] = new SelectList(_context.HoaDonNhap, "MaHDN", "MaHDN");
            ViewData["MaSP"] = new SelectList(_context.QuanAo, "MaSP", "TenSP");
            return View();
        }

        // POST: ChiTietHDNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHDN,SLNhap,MaSP")] ChiTietHDN chiTietHDN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHDN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHDN"] = new SelectList(_context.HoaDonNhap, "MaHDN", "MaHDN", chiTietHDN.MaHDN);
            ViewData["MaSP"] = new SelectList(_context.QuanAo, "MaSP", "TenSP", chiTietHDN.MaSP);
            return View(chiTietHDN);
        }

        // GET: ChiTietHDNs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChiTietHDN == null)
            {
                return NotFound();
            }

            var chiTietHDN = await _context.ChiTietHDN.FindAsync(id);
            if (chiTietHDN == null)
            {
                return NotFound();
            }
            ViewData["MaHDN"] = new SelectList(_context.HoaDonNhap, "MaHDN", "MaHDN", chiTietHDN.MaHDN);
            ViewData["MaSP"] = new SelectList(_context.QuanAo, "MaSP", "TenSP", chiTietHDN.MaSP);
            return View(chiTietHDN);
        }

        // POST: ChiTietHDNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHDN,SLNhap,MaSP")] ChiTietHDN chiTietHDN)
        {
            if (id != chiTietHDN.MaHDN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHDN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHDNExists(chiTietHDN.MaHDN))
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
            ViewData["MaHDN"] = new SelectList(_context.HoaDonNhap, "MaHDN", "MaHDN", chiTietHDN.MaHDN);
            ViewData["MaSP"] = new SelectList(_context.QuanAo, "MaSP", "TenSP", chiTietHDN.MaSP);
            return View(chiTietHDN);
        }

        // GET: ChiTietHDNs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChiTietHDN == null)
            {
                return NotFound();
            }

            var chiTietHDN = await _context.ChiTietHDN
                .Include(c => c.HoaDonNhap)
                .Include(c => c.QuanAo)
                .FirstOrDefaultAsync(m => m.MaHDN == id);
            if (chiTietHDN == null)
            {
                return NotFound();
            }

            return View(chiTietHDN);
        }

        // POST: ChiTietHDNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChiTietHDN == null)
            {
                return Problem("Entity set 'WebBanHangContext.ChiTietHDN'  is null.");
            }
            var chiTietHDN = await _context.ChiTietHDN.FindAsync(id);
            if (chiTietHDN != null)
            {
                _context.ChiTietHDN.Remove(chiTietHDN);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHDNExists(string id)
        {
          return (_context.ChiTietHDN?.Any(e => e.MaHDN == id)).GetValueOrDefault();
        }
    }
}
