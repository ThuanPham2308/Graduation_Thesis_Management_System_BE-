using Graduation_Thesis_Management_System_BE.Models.Dtos.TopicDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _service;

        public TopicController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var topic = await _service.GetByIdAsync(id);
            if (topic == null) return NotFound();
            return Ok(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CreateTopicDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
