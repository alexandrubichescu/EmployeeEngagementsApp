using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services.Auth;
using Services.DTO;
using Services.Interfaces;

namespace EmployeeEngagementsApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Role.Admin)]
    public async Task<ActionResult> GetAll()
    {
        var userList = await _userService.GetAllUsersAsync();
        return Ok(userList);
    }

    [HttpGet("ranking")]
    [Authorize(Role.Admin)]
    public async Task<ActionResult> GetAllSortedByPoints()
    {
        var userList = await _userService.GetAllUsersAsync();
        userList = userList.OrderByDescending(u => u.Points).ToList();
        return Ok(userList);
    }


    [HttpGet("{id}")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user != null)
        {
            return Ok(user);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> CreateUser([FromBody] AddUserDTO userDTO)
    {
        var userId = await _userService.AddUserAsync(userDTO);
        if (ModelState.IsValid)
        {
            return Ok(userId);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO userDTO)
    {
        await _userService.UpdateUserAsync(userDTO);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var succes = await _userService.DeleteUserAsync(id);
        if (succes)
        {
            return Ok(succes);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("{id}/points")]
    [Authorize(Role.Admin)]
    public async Task<ActionResult> AddPoints(int id, [FromBody] int points)
    {
        await _userService.AddUserPointsAsync(id, points);
        return Ok();
    }
}

