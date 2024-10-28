using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTaiSan.Entity
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MA_NV { get; set; }
        public string TEN_NV { get; set; }
        public string QUAN_LY_BOI { get; set; }
        public string DIA_CHI { get; set; }
        public string SDT { get; set; }
        public bool GIOI_TINH { get; set; }
    }
}
