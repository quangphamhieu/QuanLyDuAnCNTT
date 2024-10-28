using System.ComponentModel.DataAnnotations;

namespace QuanLyTaiSan.Dtos.NhanVien
{
    public class CreateNhanVienDto
    {
        [Required(ErrorMessage = "Mã nhân viên không được bỏ trống")]
        [MaxLength(50, ErrorMessage = "Mã nhân viên không được vượt quá 50 ký tự")]
        public string MA_NV { get; set; }

        [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
        public string TEN_NV { get; set; }

        public string QUAN_LY_BOI { get; set; }
        public string DIA_CHI { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        public bool GIOI_TINH { get; set; }
    }
}
