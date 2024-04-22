using System.ComponentModel.DataAnnotations;
namespace WebBanHang.Models
{
    public class NhaCungCap
    {
        [Key]
        [StringLength(50)]
        public string? MaNCC { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenNCC { get; set; }

        public ICollection<HoaDonNhap>? HoaDonNhaps { get; set; }
    }
}
