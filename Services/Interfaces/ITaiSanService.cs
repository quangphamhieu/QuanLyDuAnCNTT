using QuanLyTaiSan.Dtos.TaiSan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Services.Interfaces
{
    public interface ITaiSanService
    {
        Task CreateTaiSan(CreateTaiSanDto input);
        Task UpdateTaiSan(UpdateTaiSanDto input);
        Task DeleteTaiSan(int id);
        TaiSanDto GetTaiSanById(int id);
        List<TaiSanDto> GetAllTaiSan();
    }
}
