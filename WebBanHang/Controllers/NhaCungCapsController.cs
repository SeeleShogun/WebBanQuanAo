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
    
    public class NhaCungCapsController : Controller
    {
        private readonly WebBanHangContext _context;

        public NhaCungCapsController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: NhaCungCaps
        public async Task<IActionResult> Index(string SearchString)
        {
              return _context.NhaCungCap != null ? 
                          View(await _context.NhaCungCap.Where(m => m.TenNCC.Contains(SearchString) || SearchString == null).ToListAsync()) :
                          Problem("Entity set 'WebBanHangContext.NhaCungCap'  is null.");
        }

        // GET: NhaCungCaps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhaCungCap == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNCC,TenNCC")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaCungCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhaCungCap == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap.FindAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNCC,TenNCC")] NhaCungCap nhaCungCap)
        {
            if (id != nhaCungCap.MaNCC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaCungCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhaCungCap.MaNCC))
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
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhaCungCap == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhaCungCap == null)
            {
                return Problem("Entity set 'WebBanHangContext.NhaCungCap'  is null.");
            }
            var nhaCungCap = await _context.NhaCungCap.FindAsync(id);
            if (nhaCungCap != null)
            {
                _context.NhaCungCap.Remove(nhaCungCap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapExists(string id)
        {
          return (_context.NhaCungCap?.Any(e => e.MaNCC == id)).GetValueOrDefault();
        }
    }
}
