using Codetest.Interfaces;
using Codetest.Models.Requests;
using Codetest.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Codetest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{

    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(
        IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        try
        {
            return Ok(await _authenticateService.Login(model));
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        try
        {
            await _authenticateService.Register(model);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }
}