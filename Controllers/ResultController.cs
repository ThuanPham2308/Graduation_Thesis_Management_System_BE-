using Graduation_Thesis_Management_System_BE.Models.Dtos.ResultDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _service;

        public ResultController(IResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetByTopic(Guid topicId)
        {
            var result = await _service.GetByTopicIdAsync(topicId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateResultDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created result successfully");
        }

        [HttpPut("{topicId}")]
        public async Task<IActionResult> Update(Guid topicId, UpdateResultDto dto)
        {
            await _service.UpdateAsync(topicId, dto);
            return Ok("Updated result successfully");
        }
    }
}
