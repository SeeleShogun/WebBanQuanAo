using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class HoaDonNhap
    {
        [Key]
        [StringLength(50)]
        public string? MaHDN { get; set; }

        [Required]
        public DateTime NgayNhap { get; set; }

        [Required]
        public string? MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public NhaCungCap? NhaCungCap { get; set; }

        public ICollection<ChiTietHDN>? ChiTietHDNs { get; set; }
    }
}
