using Graduation_Thesis_Management_System_BE.Models.Dtos.ClassDtos;
using Graduation_Thesis_Management_System_BE.Models.Entities;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CreateClassDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
