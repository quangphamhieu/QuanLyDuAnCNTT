using Microsoft.EntityFrameworkCore;
using QuanLyTaiSan.Entity;

namespace QuanLyTaiSan.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TaiSan> TaiSans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Các cấu hình bổ sung nếu cần
        }
    }
}
