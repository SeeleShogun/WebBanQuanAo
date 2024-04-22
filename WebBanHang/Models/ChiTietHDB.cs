using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class ChiTietHDB
    {
        [Key]
        [StringLength(50)]
        public string? MaGioHang { get; set; }
        [ForeignKey("MaGioHang")]
        public GioHang? GioHang { get; set; }

        [Required]
        public int SLBan { get; set; }

        [Required]
        public string? MaSP { get; set; }
        [ForeignKey("MaSP")]
        public QuanAo? QuanAo { get; set; }

    }
}
