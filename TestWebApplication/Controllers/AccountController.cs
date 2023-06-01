using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password)
    {
        var result = await _userService.RegisterUser(username, password);
        if (!result)
        {
            return BadRequest("User already exists");
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _userService.AuthenticateUser(username, password);
        if (!result)
        {
            return Unauthorized();
        }

        return Ok();
    }
}
