using System.ComponentModel.DataAnnotations;
namespace WebBanHang.Models
{
    public class ChatLieu
    {
        [Key]
        [StringLength(50)]
        public string? MaChatLieu { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenChatLieu { get; set; }

        [StringLength(500)]
        public string? MoTaChatLieu { get; set; }

        [StringLength(100)]
        public string? AnhCL { get; set; }

        public int TTChatLieu { get; set; }

        public ICollection<QuanAo>? QuanAos { get; set; }

    }
}
