using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly WebBanHangContext _context;
        int PageSize = 8;
        public HomeController(WebBanHangContext context)
        {
            _context = context;
        }

        public IActionResult Index(string SearchString, int productPage = 1)
        {
            var _quanao = _context.QuanAo.Include(q => q.ChatLieu).Include(q => q.TheLoai).Include(q => q.ThuongHieu).Where(m => m.TenSP.Contains(SearchString) || SearchString == null)
                .Skip((productPage-1)*PageSize)
                .Take(PageSize);
            return View(_quanao.ToList());
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}