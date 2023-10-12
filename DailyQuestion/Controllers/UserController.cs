using System.Security.Claims;
using Entities.Models;
using Entities.Models.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;

namespace DailyQuestion.Controllers;


[ApiController]
[Route("/api/v1/users")]
[Authorize]

public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<UserModel> PostNewUser([FromBody] SignUpDTO user)
    {
        return await _userService.AddNewUser(user);
        
    }
    
    [AllowAnonymous]
    [HttpPost("log-in")]
    public async Task LogInUser([FromBody] LogInDto credentials)
    {
        var user = await _userService.LogInUser(credentials);
        if (user == null)
        {
            throw new UnsuccessfulLoginException("The provided email or password is not right.");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email)
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        CookieOptions cookieOptions = new CookieOptions();
        cookieOptions.Secure = true;
        Response.Cookies.Append("id", user.Id.ToString(), cookieOptions);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity)
        );
    }
}