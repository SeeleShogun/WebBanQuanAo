using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? SoDT { get; set; }
        public string? UserRole { get; set; }

        public ICollection<GioHang>? GioHangs { get; set; }
    }
}
