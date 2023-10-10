using Entities.Models;
using Entities.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DailyQuestion.Controllers;


[ApiController]
[Route("/api/v1/users")]
//[Authorize]

public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    //[AllowAnonymous]
    [HttpPost]
    public async Task<UserModel> PostNewUser([FromBody] SignUpDTO user)
    {
        return await _userService.AddNewUser(user);
        
    }
}