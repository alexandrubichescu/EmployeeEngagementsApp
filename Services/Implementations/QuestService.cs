using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations;

public class QuestService : IQuestService
{
    private readonly IQuestRepository _questRepository;
    private readonly IMapper _mapper;

    public QuestService(IQuestRepository questRepository, IMapper mapper)
    {
        _questRepository = questRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestDTO>> GetAllQuestsAsync()
    {
        var quests = await _questRepository.GetAllQuestsAsync();
        return _mapper.Map<IEnumerable<QuestDTO>>(quests);
    }

    public async Task<QuestDTO> GetQuestByIdAsync(int id)
    {
        var quest = await _questRepository.GetQuestByIdAsync(id);
        return _mapper.Map<QuestDTO>(quest);
    }

    public async Task CreateQuestAsync(QuestDTO quest)
    {
        var newQuest = _mapper.Map<Quest>(quest);
        await _questRepository.CreateQuestAsync(newQuest);
    }

    public async Task UpdateQuestAsync(int id, QuestDTO quest)
    {
        var existingQuest = await _questRepository.GetQuestByIdAsync(id);
        if (existingQuest == null)
        {
            throw new ArgumentException($"Quest with id {id} not found.");
        }

        var updatedQuest = _mapper.Map<Quest>(quest);
        updatedQuest.Id = id;
        await _questRepository.UpdateQuestAsync(updatedQuest);
    }

    public async Task DeleteQuestAsync(int id)
    {
        await _questRepository.DeleteQuestAsync(id);
    }
   
}
