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
   
    public class ThuongHieusController : Controller
    {

        private readonly WebBanHangContext _context;

        public ThuongHieusController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: ThuongHieus
        public async Task<IActionResult> Index(string SearchString)
        {
              return _context.ThuongHieu != null ? 
                          View(await _context.ThuongHieu.Where(m => m.TenThuongHieu.Contains(SearchString) || SearchString == null).ToListAsync()) :
                          Problem("Entity set 'WebBanHangContext.ThuongHieu'  is null.");
        }

        // GET: ThuongHieus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ThuongHieu == null)
            {
                return NotFound();
            }

            var thuongHieu = await _context.ThuongHieu
                .FirstOrDefaultAsync(m => m.MaThuongHieu == id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            return View(thuongHieu);
        }

        // GET: ThuongHieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThuongHieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThuongHieu,TenThuongHieu,MoTaThuongHieu,AnhTH,TTThuongHieu")] ThuongHieu thuongHieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuongHieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuongHieu);
        }

        // GET: ThuongHieus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ThuongHieu == null)
            {
                return NotFound();
            }

            var thuongHieu = await _context.ThuongHieu.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }
            return View(thuongHieu);
        }

        // POST: ThuongHieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThuongHieu,TenThuongHieu,MoTaThuongHieu,AnhTH,TTThuongHieu")] ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.MaThuongHieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuongHieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuongHieuExists(thuongHieu.MaThuongHieu))
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
            return View(thuongHieu);
        }

        // GET: ThuongHieus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ThuongHieu == null)
            {
                return NotFound();
            }

            var thuongHieu = await _context.ThuongHieu
                .FirstOrDefaultAsync(m => m.MaThuongHieu == id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            return View(thuongHieu);
        }

        // POST: ThuongHieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ThuongHieu == null)
            {
                return Problem("Entity set 'WebBanHangContext.ThuongHieu'  is null.");
            }
            var thuongHieu = await _context.ThuongHieu.FindAsync(id);
            if (thuongHieu != null)
            {
                _context.ThuongHieu.Remove(thuongHieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuongHieuExists(string id)
        {
          return (_context.ThuongHieu?.Any(e => e.MaThuongHieu == id)).GetValueOrDefault();
        }
    }
}
