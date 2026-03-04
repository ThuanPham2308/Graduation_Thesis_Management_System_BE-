using Graduation_Thesis_Management_System_BE.Models.Dtos.LecturerAssignmentDTOs;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/lecturer-assignments")]
    public class LecturerAssignmentController : ControllerBase
    {
        private readonly ILecturerAssignmentService _service;

        public LecturerAssignmentController(ILecturerAssignmentService service)
        {
            _service = service;
        }

        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopic(string topicId)
        {
            return Ok(await _service.GetByTopicAsync(topicId));
        }

        [HttpPost]
        public async Task<IActionResult> Assign(CreateLecturerAssignmentDto dto)
        {
            await _service.AssignAsync(dto);
            return Ok("Assign lecturer successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string topicId, string lecturerId, string role)
        {
            await _service.RemoveAsync(topicId, lecturerId, role);
            return Ok("Remove lecturer assignment successfully");
        }
    }
}
