using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    // Endpoint for user registration use case
    [HttpPost("register")] //POST api/auth
    public async Task<IActionResult>  Register(RegisterRequest registerRequest)
    {
        // check for invalid registerRequest
        if (registerRequest == null)
        {
            return BadRequest("Inavlid registeration data");
        }

        //call the register method from the service
        AuthenticationResponse? authResponse = await _usersService.Register(registerRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            return BadRequest(authResponse);
        }
        else
        {
            return Ok(authResponse);
        }
    }

    //Endpoint for user login use case
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // check for invalide loginrequest
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse ==null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }
}
