using QuanLyTaiSan.DbContexts;
using QuanLyTaiSan.Services.Implements;
using QuanLyTaiSan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuanLyTaiSan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cấu hình các dịch vụ trong container
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Giữ nguyên tên thuộc tính JSON
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Cấu hình DbContext và nạp Connection String
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            // Đăng ký dịch vụ cho NhanVien và TaiSan
            builder.Services.AddScoped<INhanVienService, NhanVienService>();
            builder.Services.AddScoped<ITaiSanService, TaiSanService>();

            var app = builder.Build();

            // Cấu hình HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
