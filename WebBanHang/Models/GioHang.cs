using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class GioHang
    {
        [Key]
        [StringLength(50)]
        public string? MaGioHang { get; set; }
        [Required]

        public int SoLuong { get; set; }

        [Required]
        public int TongTien { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<ChiTietHDB>? ChiTietHDBs { get; set; }
    }
}
