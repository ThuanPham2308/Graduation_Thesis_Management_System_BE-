using Graduation_Thesis_Management_System_BE.Models.Dtos.AdminDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Tạo admin thành công");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok("Xóa admin thành công");
        }
    }
}
