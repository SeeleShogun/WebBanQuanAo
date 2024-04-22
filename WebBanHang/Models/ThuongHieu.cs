using System.ComponentModel.DataAnnotations;
namespace WebBanHang.Models
{
    public class ThuongHieu
    {
        [Key]
        [StringLength(50)]
        public string? MaThuongHieu { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenThuongHieu { get; set; }

        [StringLength(500)]
        public string? MoTaThuongHieu { get; set; }

        [StringLength(100)]
        public string? AnhTH { get; set; }

        public int TTThuongHieu { get; set; }

        public ICollection<QuanAo>? QuanAos { get; set; }

    }
}
