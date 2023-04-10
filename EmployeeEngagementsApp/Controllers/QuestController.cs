using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace EmployeeEngagementsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpPost]
    public async Task<IActionResult> AddQuest([FromBody] QuestDTO questDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _questService.CreateQuestAsync(questDTO);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuest(int id, [FromBody] QuestDTO questDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _questService.UpdateQuestAsync(id, questDTO);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuest(int id)
    {
        await _questService.DeleteQuestAsync(id);
        return NoContent();
    }
}
