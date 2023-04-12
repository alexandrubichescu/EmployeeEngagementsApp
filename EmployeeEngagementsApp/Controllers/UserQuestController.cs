using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services.Auth;
using Services.DTO;
using Services.Interfaces;

namespace EmployeeEngagementsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserQuestController : ControllerBase
{
    private readonly IUserQuestService _userQuestService;

    public UserQuestController(IUserQuestService userQuestService)
    {
        _userQuestService = userQuestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserQuests()
    {
        var currentUser = (User?)HttpContext.Items["User"];

        if (currentUser is null)
            return BadRequest(ModelState);

        var questDTOs = await _userQuestService.GetUserCompletedQuestsAsync(currentUser.Id);

        return Ok(questDTOs);
    }

    [HttpPost]
    public async Task<IActionResult> CompleteQuest([FromBody] AddUserQuestDto userQuestDTO)
    {
        var currentUser = (User?)HttpContext.Items["User"];

        if (currentUser is null)
            return BadRequest(ModelState);

        await _userQuestService.CompleteUserQuest(currentUser.Id ,userQuestDTO);

        return Ok();
    }
}
