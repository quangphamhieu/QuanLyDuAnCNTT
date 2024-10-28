using QuanLyTaiSan.DbContexts;
using QuanLyTaiSan.Dtos.NhanVien;
using QuanLyTaiSan.Entity;
using QuanLyTaiSan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Services.Implements
{
    public class NhanVienService : INhanVienService
    {
        private readonly ApplicationDbContext _dbContext;

        public NhanVienService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNhanVien(CreateNhanVienDto input)
        {
            var nhanVien = new NhanVien
            {
                MA_NV = input.MA_NV,
                TEN_NV = input.TEN_NV,
                QUAN_LY_BOI = input.QUAN_LY_BOI,
                DIA_CHI = input.DIA_CHI,
                SDT = input.SDT,
                GIOI_TINH = input.GIOI_TINH
            };
            _dbContext.NhanViens.Add(nhanVien);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNhanVien(UpdateNhanVienDto input)
        {
            var nhanVien = await _dbContext.NhanViens.FindAsync(input.Id);
            if (nhanVien == null) throw new Exception("Không tìm thấy nhân viên.");

            nhanVien.MA_NV = input.MA_NV;
            nhanVien.TEN_NV = input.TEN_NV;
            nhanVien.QUAN_LY_BOI = input.QUAN_LY_BOI;
            nhanVien.DIA_CHI = input.DIA_CHI;
            nhanVien.SDT = input.SDT;
            nhanVien.GIOI_TINH = input.GIOI_TINH;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNhanVien(int id)
        {
            var nhanVien = await _dbContext.NhanViens.FindAsync(id);
            if (nhanVien == null) throw new Exception("Không tìm thấy nhân viên.");

            _dbContext.NhanViens.Remove(nhanVien);
            await _dbContext.SaveChangesAsync();
        }

        public NhanVienDto GetNhanVienById(int id)
        {
            var nhanVien = _dbContext.NhanViens.Find(id);
            if (nhanVien == null) return null;

            return new NhanVienDto
            {
                Id = nhanVien.Id,
                MA_NV = nhanVien.MA_NV,
                TEN_NV = nhanVien.TEN_NV,
                QUAN_LY_BOI = nhanVien.QUAN_LY_BOI,
                DIA_CHI = nhanVien.DIA_CHI,
                SDT = nhanVien.SDT,
                GIOI_TINH = nhanVien.GIOI_TINH
            };
        }

        public List<NhanVienDto> GetAllNhanVien()
        {
            return _dbContext.NhanViens.Select(n => new NhanVienDto
            {
                Id = n.Id,
                MA_NV = n.MA_NV,
                TEN_NV = n.TEN_NV,
                QUAN_LY_BOI = n.QUAN_LY_BOI,
                DIA_CHI = n.DIA_CHI,
                SDT = n.SDT,
                GIOI_TINH = n.GIOI_TINH
            }).ToList();
        }
    }
}
