using Microsoft.AspNetCore.Mvc;
using WebBanHang.Data;

namespace WebBanHang.Controllers
{
    [ViewComponent(Name = "_TheLoaiSide")]
    public class _TheLoaiSideViewComponent : ViewComponent
    {
        private readonly WebBanHangContext _context;
        public _TheLoaiSideViewComponent(WebBanHangContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _theloai = _context.TheLoai.ToList();
            return View("_TheLoaiSide", _theloai);
        }
    }
}
