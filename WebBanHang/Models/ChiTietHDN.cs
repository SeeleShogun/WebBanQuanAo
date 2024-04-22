using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class ChiTietHDN
    {
        [Key]
        [StringLength(50)]
        public string? MaHDN { get; set; }
        [ForeignKey("MaHDN")]
        public HoaDonNhap? HoaDonNhap { get; set; }

        [Required]
        public int SLNhap { get; set; }

        [Required]
        public string? MaSP { get; set; }
        [ForeignKey("MaSP")]
        public QuanAo? QuanAo { get; set; }

    }
}
