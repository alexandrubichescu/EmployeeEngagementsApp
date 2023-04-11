using Microsoft.AspNetCore.Http;
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
    private readonly IQuestService _QuestService;

    public QuestController(IQuestService QuestService)
    {
        _QuestService = QuestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuests()
    {
        var QuestDTOs = await _QuestService.GetAllQuestsAsync();
        return Ok(QuestDTOs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestById(int id)
    {
        var QuestDTO = await _QuestService.GetQuestByIdAsync(id);

        if (QuestDTO == null)
        {
            return NotFound();
        }

        return Ok(QuestDTO);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddQuest([FromBody] QuestDTO QuestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _QuestService.CreateQuestAsync(QuestDTO);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateQuest(int id,[FromBody] QuestDTO QuestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _QuestService.UpdateQuestAsync(id, QuestDTO);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuest(int id)
    {
        // only admins and users who have created the Quest can delete Quests
        var currentUser = (User?)HttpContext.Items["User"];

        var isUserQuest = await _QuestService.IsUserQuest(currentUser.Id, id);

        if (currentUser?.Role != Role.Admin && !isUserQuest)
            return Unauthorized(new { message = "Unauthorized" });

        await _QuestService.DeleteQuestAsync(id);

        return Ok();
    }

    [HttpPost("aprove")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> ApproveQuest(int id)
    {
        var currentUser = (User?)HttpContext.Items["User"];
        if (currentUser == null)
            return BadRequest(ModelState);
        await _QuestService.ApproveQuest(currentUser.Id, id);

        return Ok();
    }
   
    [HttpPost("reject")]
    [Authorize(Role.Admin)]
    public async Task<IActionResult> RejectQuest(int id)
    {
        var currentUser = (User?)HttpContext.Items["User"];
        
        if(currentUser==null) 
            return BadRequest(ModelState);
        await _QuestService.RejectQuest(currentUser.Id, id);

        return Ok();
    }
}
