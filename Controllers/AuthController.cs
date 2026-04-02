using Graduation_Thesis_Management_System_BE.Models.Dtos.AuthDtos;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthController(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userService.LoginAsync(model.Username, model.Password);

        if (user == null)
            return Unauthorized("Sai tài khoản hoặc mật khẩu");

        var token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            token = token
        });
    }
}