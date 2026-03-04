using Graduation_Thesis_Management_System_BE.Models.Dtos.ThesisDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/theses")]
    public class ThesisController : ControllerBase
    {
        private readonly IThesisService _service;

        public ThesisController(IThesisService service)
        {
            _service = service;
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopic(string topicId)
        {
            var result = await _service.GetByTopicAsync(topicId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateThesisDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Submit thesis successfully");
        }

        [HttpPut("{thesisId}")]
        public async Task<IActionResult> Update(string thesisId, UpdateThesisDto dto)
        {
            await _service.UpdateAsync(thesisId, dto);
            return Ok("Update thesis successfully");
        }

        [HttpPut("{thesisId}/approve")]
        public async Task<IActionResult> Approve(string thesisId, ApproveThesisDto dto)
        {
            await _service.ApproveAsync(thesisId, dto);
            return Ok("Approve thesis successfully");
        }
    }
}
