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
   
    public class ChatLieusController : Controller
    {
        private readonly WebBanHangContext _context;

        public ChatLieusController(WebBanHangContext context)
        {
            _context = context;
        }

        // GET: ChatLieus
        public async Task<IActionResult> Index(string SearchString)
        {
              return _context.ChatLieu != null ? 
                          View(await _context.ChatLieu.Where(m => m.TenChatLieu.Contains(SearchString) || SearchString == null).ToListAsync()) :
                          Problem("Entity set 'WebBanHangContext.ChatLieu'  is null.");
        }

        // GET: ChatLieus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu
                .FirstOrDefaultAsync(m => m.MaChatLieu == id);
            if (chatLieu == null)
            {
                return NotFound();
            }

            return View(chatLieu);
        }

        // GET: ChatLieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatLieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChatLieu,TenChatLieu,MoTaChatLieu,AnhCL,TTChatLieu")] ChatLieu chatLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatLieu);
        }

        // GET: ChatLieus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu.FindAsync(id);
            if (chatLieu == null)
            {
                return NotFound();
            }
            return View(chatLieu);
        }

        // POST: ChatLieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChatLieu,TenChatLieu,MoTaChatLieu,AnhCL,TTChatLieu")] ChatLieu chatLieu)
        {
            if (id != chatLieu.MaChatLieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatLieuExists(chatLieu.MaChatLieu))
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
            return View(chatLieu);
        }

        // GET: ChatLieus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu
                .FirstOrDefaultAsync(m => m.MaChatLieu == id);
            if (chatLieu == null)
            {
                return NotFound();
            }

            return View(chatLieu);
        }

        // POST: ChatLieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChatLieu == null)
            {
                return Problem("Entity set 'WebBanHangContext.ChatLieu'  is null.");
            }
            var chatLieu = await _context.ChatLieu.FindAsync(id);
            if (chatLieu != null)
            {
                _context.ChatLieu.Remove(chatLieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatLieuExists(string id)
        {
          return (_context.ChatLieu?.Any(e => e.MaChatLieu == id)).GetValueOrDefault();
        }
    }
}
