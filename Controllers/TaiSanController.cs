using Microsoft.AspNetCore.Mvc;
using QuanLyTaiSan.Dtos.TaiSan;
using QuanLyTaiSan.Services.Interfaces;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaiSanController : ControllerBase
    {
        private readonly ITaiSanService _taiSanService;

        public TaiSanController(ITaiSanService taiSanService)
        {
            _taiSanService = taiSanService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTaiSan([FromBody] CreateTaiSanDto taiSanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taiSanService.CreateTaiSan(taiSanDto);
            return Ok("Tài sản đã được thêm thành công.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTaiSan([FromBody] UpdateTaiSanDto taiSanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taiSanService.UpdateTaiSan(taiSanDto);
            return Ok("Tài sản đã được cập nhật thành công.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTaiSan(int id)
        {
            try
            {
                await _taiSanService.DeleteTaiSan(id);
                return Ok("Tài sản đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAllTaiSan()
        {
            var taiSans = _taiSanService.GetAllTaiSan();
            return Ok(taiSans);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetTaiSanById(int id)
        {
            var taiSan = _taiSanService.GetTaiSanById(id);
            if (taiSan == null)
                return NotFound("Không tìm thấy tài sản.");

            return Ok(taiSan);
        }
    }
}
