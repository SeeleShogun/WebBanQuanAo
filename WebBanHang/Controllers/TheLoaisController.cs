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
  
    public class TheLoaisController : Controller
    {
        private readonly WebBanHangContext _context;

        public TheLoaisController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: TheLoais
        public async Task<IActionResult> Index(string SearchString)
        {
              return _context.TheLoai != null ? 
                          View(await _context.TheLoai.Where(m => m.TenTheLoai.Contains(SearchString) || SearchString == null).ToListAsync()) :
                          Problem("Entity set 'WebBanHangContext.TheLoai'  is null.");
        }

        // GET: TheLoais/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai
                .FirstOrDefaultAsync(m => m.MaTheLoai == id);
            if (theLoai == null)
            {
                return NotFound();
            }

            return View(theLoai);
        }

        // GET: TheLoais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheLoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTheLoai,TenTheLoai,MoTaTheLoai,AnhTL,TTTheLoai")] TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theLoai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theLoai);
        }

        // GET: TheLoais/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai.FindAsync(id);
            if (theLoai == null)
            {
                return NotFound();
            }
            return View(theLoai);
        }

        // POST: TheLoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTheLoai,TenTheLoai,MoTaTheLoai,AnhTL,TTTheLoai")] TheLoai theLoai)
        {
            if (id != theLoai.MaTheLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theLoai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheLoaiExists(theLoai.MaTheLoai))
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
            return View(theLoai);
        }

        // GET: TheLoais/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai
                .FirstOrDefaultAsync(m => m.MaTheLoai == id);
            if (theLoai == null)
            {
                return NotFound();
            }

            return View(theLoai);
        }

        // POST: TheLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TheLoai == null)
            {
                return Problem("Entity set 'WebBanHangContext.TheLoai'  is null.");
            }
            var theLoai = await _context.TheLoai.FindAsync(id);
            if (theLoai != null)
            {
                _context.TheLoai.Remove(theLoai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheLoaiExists(string id)
        {
          return (_context.TheLoai?.Any(e => e.MaTheLoai == id)).GetValueOrDefault();
        }
    }
}
