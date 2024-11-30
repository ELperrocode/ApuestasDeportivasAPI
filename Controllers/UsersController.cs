// Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost("register")]
    public async Task<ActionResult<User>> Register([FromBody] UserRegisterDto userDto)
    {
        var user = await _userService.RegisterUser(userDto.Username, userDto.Password);
        return Ok(user);
    }


    [HttpPost("login")]
    public async Task<ActionResult<User>> Login([FromBody] UserLoginDto userDto)
    {
        var user = await _userService.LoginUser(userDto.Username, userDto.Password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }

    
    [HttpPost("recharge")]
    public async Task<ActionResult<User>> RechargeWallet([FromBody] RechargeWalletDto rechargeDto)
    {
        var user = await _userService.RechargeWallet(rechargeDto.UserId, rechargeDto.Amount);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

}

public class UserRegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class RechargeWalletDto
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
}
