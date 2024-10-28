using Microsoft.AspNetCore.Mvc;
using QuanLyTaiSan.Dtos.NhanVien;
using QuanLyTaiSan.Services.Interfaces;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNhanVien([FromBody] CreateNhanVienDto nhanVienDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _nhanVienService.CreateNhanVien(nhanVienDto);
            return Ok("Nhân viên đã được thêm thành công.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNhanVien([FromBody] UpdateNhanVienDto nhanVienDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _nhanVienService.UpdateNhanVien(nhanVienDto);
            return Ok("Nhân viên đã được cập nhật thành công.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNhanVien(int id)
        {
            try
            {
                await _nhanVienService.DeleteNhanVien(id);
                return Ok("Nhân viên đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAllNhanVien()
        {
            var nhanViens = _nhanVienService.GetAllNhanVien();
            return Ok(nhanViens);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetNhanVienById(int id)
        {
            var nhanVien = _nhanVienService.GetNhanVienById(id);
            if (nhanVien == null)
                return NotFound("Không tìm thấy nhân viên.");

            return Ok(nhanVien);
        }
    }
}
