using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class QuanAo
    {
        [Key]
        [StringLength(50)]
        public string? MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenSP { get; set; }

        [Required]
        public int? SoLuong { get; set; }

        [Required]
        public decimal? GiaNhap { get; set; }

        [Required]
        public decimal? GiaBan { get; set; }

        [StringLength(100)]
        public string? Anh { get; set; }

        [StringLength(500)]
        public string? MoTa { get; set; }       

        [StringLength(50)]
        public string? MauSac { get; set; }

        [StringLength(50)]
        public string? KichCo { get; set; }

        [StringLength(50)]
        public string? MaThuongHieu { get; set; }
        [ForeignKey("MaThuongHieu")]
        public ThuongHieu? ThuongHieu  { get; set; }

        [StringLength(50)]
        public string? MaTheLoai { get; set; }
        [ForeignKey("MaTheLoai")]
        public TheLoai? TheLoai { get; set; }

        [StringLength(50)]
        public string? MaChatLieu { get; set; }
        [ForeignKey("MaChatLieu")]
        public ChatLieu? ChatLieu { get; set; }

        public ICollection<ChiTietHDB>? ChiTietHDBs { get; set; }
        public ICollection<ChiTietHDN>? ChiTietHDNs { get; set; }
    }

}
