using QuanLyTaiSan.Dtos.NhanVien;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Services.Interfaces
{
    public interface INhanVienService
    {
        Task CreateNhanVien(CreateNhanVienDto input);
        Task UpdateNhanVien(UpdateNhanVienDto input);
        Task DeleteNhanVien(int id);
        NhanVienDto GetNhanVienById(int id);
        List<NhanVienDto> GetAllNhanVien();
    }
}
