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
    
    public class QuanAosController : Controller
    {
        private readonly WebBanHangContext _context;

        public QuanAosController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: QuanAos
        public async Task<IActionResult> Index(string SearchString)
        {
            var webBanHangContext = _context.QuanAo.Include(q => q.ChatLieu).Include(q => q.TheLoai).Include(q => q.ThuongHieu).Where(m => m.TenSP.Contains(SearchString) || SearchString == null);
            return View(await webBanHangContext.ToListAsync());
        }

        public async Task<IActionResult> QuanAoByTheLoai(string Matheloai)
        {
            var webBanHangContext = _context.QuanAo.Include(q => q.ChatLieu).Include(q => q.TheLoai).Include(q => q.ThuongHieu).Where(q=>q.MaTheLoai == Matheloai);
            return View(await webBanHangContext.ToListAsync());
        }


        //Get: QuanAos/QuanAoDetails

        public async Task<IActionResult> QuanAoDetails(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo
                .Include(q => q.ChatLieu)
                .Include(q => q.TheLoai)
                .Include(q => q.ThuongHieu)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (quanAo == null)
            {
                return NotFound();
            }

            return View(quanAo);
        }

        // GET: QuanAos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo
                .Include(q => q.ChatLieu)
                .Include(q => q.TheLoai)
                .Include(q => q.ThuongHieu)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (quanAo == null)
            {
                return NotFound();
            }

            return View(quanAo);
        }

        // GET: QuanAos/Create
        public IActionResult Create()
        {
            ViewData["MaChatLieu"] = new SelectList(_context.ChatLieu, "MaChatLieu", "TenChatLieu");
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai");
            ViewData["MaThuongHieu"] = new SelectList(_context.ThuongHieu, "MaThuongHieu", "TenThuongHieu");
            return View();
        }

        // POST: QuanAos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,SoLuong,GiaNhap,GiaBan,Anh,MoTa,MauSac,KichCo,MaThuongHieu,MaTheLoai,MaChatLieu")] QuanAo quanAo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanAo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChatLieu"] = new SelectList(_context.ChatLieu, "MaChatLieu", "TenChatLieu", quanAo.MaChatLieu);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", quanAo.MaTheLoai);
            ViewData["MaThuongHieu"] = new SelectList(_context.ThuongHieu, "MaThuongHieu", "TenThuongHieu", quanAo.MaThuongHieu);
            return View(quanAo);
        }

        // GET: QuanAos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo.FindAsync(id);
            if (quanAo == null)
            {
                return NotFound();
            }
            ViewData["MaChatLieu"] = new SelectList(_context.ChatLieu, "MaChatLieu", "TenChatLieu", quanAo.MaChatLieu);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", quanAo.MaTheLoai);
            ViewData["MaThuongHieu"] = new SelectList(_context.ThuongHieu, "MaThuongHieu", "TenThuongHieu", quanAo.MaThuongHieu);
            return View(quanAo);
        }

        // POST: QuanAos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSP,TenSP,SoLuong,GiaNhap,GiaBan,Anh,MoTa,MauSac,KichCo,MaThuongHieu,MaTheLoai,MaChatLieu")] QuanAo quanAo)
        {
            if (id != quanAo.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanAo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanAoExists(quanAo.MaSP))
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
            ViewData["MaChatLieu"] = new SelectList(_context.ChatLieu, "MaChatLieu", "TenChatLieu", quanAo.MaChatLieu);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", quanAo.MaTheLoai);
            ViewData["MaThuongHieu"] = new SelectList(_context.ThuongHieu, "MaThuongHieu", "TenThuongHieu", quanAo.MaThuongHieu);
            return View(quanAo);
        }

        // GET: QuanAos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo
                .Include(q => q.ChatLieu)
                .Include(q => q.TheLoai)
                .Include(q => q.ThuongHieu)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (quanAo == null)
            {
                return NotFound();
            }

            return View(quanAo);
        }

        // POST: QuanAos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QuanAo == null)
            {
                return Problem("Entity set 'WebBanHangContext.QuanAo'  is null.");
            }
            var quanAo = await _context.QuanAo.FindAsync(id);
            if (quanAo != null)
            {
                _context.QuanAo.Remove(quanAo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanAoExists(string id)
        {
          return (_context.QuanAo?.Any(e => e.MaSP == id)).GetValueOrDefault();
        }
    }
}
