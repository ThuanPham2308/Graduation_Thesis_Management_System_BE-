using Graduation_Thesis_Management_System_BE.Models.Dtos.OutlinePlanDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/outline-plans")]
    public class OutlinePlanController : ControllerBase
    {
        private readonly IOutlinePlanService _service;

        public OutlinePlanController(IOutlinePlanService service)
        {
            _service = service;
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopic(Guid topicId)
        {
            var result = await _service.GetByTopicAsync(topicId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOutlinePlanDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Create outline plan successfully");
        }

        [HttpPut("{outlineId}")]
        public async Task<IActionResult> Update(Guid outlineId, UpdateOutlinePlanDto dto)
        {
            await _service.UpdateAsync(outlineId, dto);
            return Ok("Update outline plan successfully");
        }
    }
}
