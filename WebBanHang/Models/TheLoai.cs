using System.ComponentModel.DataAnnotations;
namespace WebBanHang.Models
{
    public class TheLoai
    {
        [Key]
        [StringLength(50)]
        public string? MaTheLoai { get; set; }

        [Required]
        [StringLength(50)]       
        public string? TenTheLoai { get; set; }

        [StringLength(500)]
        public string? MoTaTheLoai { get; set; }

        [StringLength(100)]
        public string? AnhTL { get; set; }

        public int TTTheLoai { get; set; }

        public ICollection<QuanAo>? QuanAos { get; set; }

    }
}
