using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;

namespace WebBanHang.Data
{
    public class WebBanHangContext : DbContext
    {
        public WebBanHangContext (DbContextOptions<WebBanHangContext> options)
            : base(options)
        {
        }

        public DbSet<WebBanHang.Models.User> User { get; set; } = default!;

        public DbSet<WebBanHang.Models.ThuongHieu>? ThuongHieu { get; set; }

        public DbSet<WebBanHang.Models.TheLoai>? TheLoai { get; set; }

        public DbSet<WebBanHang.Models.ChatLieu>? ChatLieu { get; set; }

        public DbSet<WebBanHang.Models.QuanAo>? QuanAo { get; set; }

        public DbSet<WebBanHang.Models.NhaCungCap>? NhaCungCap { get; set; }

        public DbSet<WebBanHang.Models.HoaDonNhap>? HoaDonNhap { get; set; }

        public DbSet<WebBanHang.Models.ChiTietHDN>? ChiTietHDN { get; set; }
    }
}
