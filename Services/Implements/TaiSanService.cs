using QuanLyTaiSan.DbContexts;
using QuanLyTaiSan.Dtos.TaiSan;
using QuanLyTaiSan.Entity;
using QuanLyTaiSan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Services.Implements
{
    public class TaiSanService : ITaiSanService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaiSanService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTaiSan(CreateTaiSanDto input)
        {
            var taiSan = new TaiSan
            {
                MA_TAI_SAN = input.MA_TAI_SAN,
                TEN_TAI_SAN = input.TEN_TAI_SAN,
                LOAI_TAI_SAN = input.LOAI_TAI_SAN,
                SO_LUONG = input.SO_LUONG
            };
            _dbContext.TaiSans.Add(taiSan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTaiSan(UpdateTaiSanDto input)
        {
            var taiSan = await _dbContext.TaiSans.FindAsync(input.Id);
            if (taiSan == null) throw new Exception("Không tìm thấy tài sản.");

            taiSan.MA_TAI_SAN = input.MA_TAI_SAN;
            taiSan.TEN_TAI_SAN = input.TEN_TAI_SAN;
            taiSan.LOAI_TAI_SAN = input.LOAI_TAI_SAN;
            taiSan.SO_LUONG = input.SO_LUONG;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTaiSan(int id)
        {
            var taiSan = await _dbContext.TaiSans.FindAsync(id);
            if (taiSan == null) throw new Exception("Không tìm thấy tài sản.");

            _dbContext.TaiSans.Remove(taiSan);
            await _dbContext.SaveChangesAsync();
        }

        public TaiSanDto GetTaiSanById(int id)
        {
            var taiSan = _dbContext.TaiSans.Find(id);
            if (taiSan == null) return null;

            return new TaiSanDto
            {
                Id = taiSan.Id,
                MA_TAI_SAN = taiSan.MA_TAI_SAN,
                TEN_TAI_SAN = taiSan.TEN_TAI_SAN,
                LOAI_TAI_SAN = taiSan.LOAI_TAI_SAN,
                SO_LUONG = taiSan.SO_LUONG
            };
        }

        public List<TaiSanDto> GetAllTaiSan()
        {
            return _dbContext.TaiSans.Select(t => new TaiSanDto
            {
                Id = t.Id,
                MA_TAI_SAN = t.MA_TAI_SAN,
                TEN_TAI_SAN = t.TEN_TAI_SAN,
                LOAI_TAI_SAN = t.LOAI_TAI_SAN,
                SO_LUONG = t.SO_LUONG
            }).ToList();
        }
    }
}
