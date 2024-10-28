using System.ComponentModel.DataAnnotations;

namespace QuanLyTaiSan.Dtos.TaiSan
{
    public class CreateTaiSanDto
    {
        [Required(ErrorMessage = "Mã tài sản không được bỏ trống")]
        [MaxLength(50, ErrorMessage = "Mã tài sản không được vượt quá 50 ký tự")]
        public string MA_TAI_SAN { get; set; }

        [Required(ErrorMessage = "Tên tài sản không được bỏ trống")]
        public string TEN_TAI_SAN { get; set; }

        public string LOAI_TAI_SAN { get; set; }

        public int SO_LUONG { get; set; }
    }
}
