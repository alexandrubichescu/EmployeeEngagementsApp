using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services.Auth;
using Services.DTO;
using Services.Interfaces;

namespace EmployeeEngagementsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class QuestController : ControllerBase
{
    private readonly IQuestService _questService;

    public QuestController(IQuestService questService)
    {
        _questService = questService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuests()
    {
        var questDTOs = await _questService.GetAllQuestsAsync();
        return Ok(questDTOs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestById(int id)
    {
        var questDTO = await _questService.GetQuestByIdAsync(id);

        if (questDTO == null)
        {
            return NotFound();
        }

        return Ok(questDTO);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddQuest([FromBody] AddQuestDTO questDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _questService.CreateQuestAsync(questDTO);

        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateQuest([FromBody] UpdateQuestDTO questDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _questService.UpdateQuestAsync(questDTO);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuest(int id)
    {
        // only admins and users who have created the quest can delete quests
        var currentUser = (User?)HttpContext.Items["User"];

        var isUserQuest = await _questService.IsUserQuest(currentUser!.Id, id);

        if (currentUser?.Role != Role.Admin && !isUserQuest)
            return Unauthorized(new { message = "Unauthorized" });

        await _questService.DeleteQuestAsync(id);

        return Ok();
    }

    [HttpPost("aprove/{id}")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> ApproveQuest(int id)
    {
        var currentUser = (User?)HttpContext.Items["User"];
        if (currentUser == null)
            return BadRequest(ModelState);
        await _questService.ApproveQuest(currentUser.Id, id);

        return Ok();
    }
   
    [HttpPost("reject/{id}")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> RejectQuest(int id)
    {
        var currentUser = (User?)HttpContext.Items["User"];
        
        if(currentUser==null) 
            return BadRequest(ModelState);
        await _questService.RejectQuest(currentUser.Id, id);

        return Ok();
    }
}
