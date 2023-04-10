using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.Interfaces;

namespace EmployeeEngagementsApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var userList = await _userService.GetAllUsersAsync();
        return Ok(userList);
    }

    [HttpGet("{id}")]
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
    public async Task<IActionResult> CreateUser([FromBody] UserDTO UserDTO)
    {
        var userId = await _userService.AddUserAsync(UserDTO);
        if (ModelState.IsValid)
        {
            return Ok(userId);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDTO UserDTO)
    {
        var succes = await _userService.UpdateUserAsync(UserDTO);
        if (succes)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
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
    public async Task<ActionResult> AddPoints(int id, [FromBody] int points)
    {
        await _userService.AddUserPointsAsync(id, points);
        return Ok();
    }

    [HttpPost("{userId}/badges/{badgeId}")] 
    public async Task<ActionResult> AddBadge(int userId, int badgeId)
    {
        await _userService.AddUserBadgeAsync(userId, badgeId);

        return Ok();
    }
}

