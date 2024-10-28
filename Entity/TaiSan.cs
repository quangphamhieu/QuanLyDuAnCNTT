using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTaiSan.Entity
{
    [Table("TaiSan")]
    public class TaiSan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MA_TAI_SAN { get; set; }
        public string TEN_TAI_SAN { get; set; }
        public string LOAI_TAI_SAN { get; set; }
        public int SO_LUONG { get; set; }
    }
}
