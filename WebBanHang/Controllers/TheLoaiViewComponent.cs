using Microsoft.AspNetCore.Mvc;
using WebBanHang.Data;

namespace WebBanHang.Controllers
{
    [ViewComponent(Name = "_TheLoai")]
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly WebBanHangContext _context;

        public TheLoaiViewComponent(WebBanHangContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _theloai = _context.TheLoai.ToList();
            return View("_TheLoai", _theloai);
        }
    }
}
