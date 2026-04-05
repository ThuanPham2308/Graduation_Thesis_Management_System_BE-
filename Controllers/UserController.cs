using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Graduation_Thesis_Management_System_BE.Models.Dtos.UserDTos;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Thesis_Management_System_BE.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("User created successfully");
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result)
                return NotFound("User not found");

            return Ok("User updated successfully");
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound("User not found");

            return Ok("User deleted successfully");
        }
    }
}
