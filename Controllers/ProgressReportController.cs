using Graduation_Thesis_Management_System_BE.Models.Dtos.ProgressReportDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/progress-reports")]
    public class ProgressReportController : ControllerBase
    {
        private readonly IProgressReportService _service;

        public ProgressReportController(IProgressReportService service)
        {
            _service = service;
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopic(Guid topicId)
        {
            return Ok(await _service.GetByTopicAsync(topicId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProgressReportDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Create progress report successfully");
        }

        [HttpPut("{reportId}")]
        public async Task<IActionResult> Update(Guid reportId, UpdateProgressReportDto dto)
        {
            await _service.UpdateAsync(reportId, dto);
            return Ok("Update progress report successfully");
        }
    }
}
