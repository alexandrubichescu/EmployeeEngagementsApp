using AutoMapper;
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

    public async Task<IEnumerable<UpdateQuestDTO>> GetAllQuestsAsync()
    {
        var quests = await _questRepository.GetAllQuestsAsync();
        return _mapper.Map<IEnumerable<UpdateQuestDTO>>(quests);
    }

    public async Task<UpdateQuestDTO> GetQuestByIdAsync(int id)
    {
        var quest = await _questRepository.GetQuestByIdAsync(id);
        return _mapper.Map<UpdateQuestDTO>(quest);
    }

    public async Task CreateQuestAsync(AddQuestDTO quest)
    {
        var newQuest = _mapper.Map<Quest>(quest);
        await _questRepository.CreateQuestAsync(newQuest);
    }

    public async Task UpdateQuestAsync(UpdateQuestDTO quest)
    {
        var existingQuest = await _questRepository.GetQuestByIdAsync(quest.Id);
        
        if (existingQuest == null)
            throw new ArgumentException($"Quest with id {quest.Id} not found.");

        existingQuest.Title = quest.Title;  
        existingQuest.Description = quest.Description;  
        existingQuest.Points = quest.Points;  

        await _questRepository.SaveChangesAsync();
    }

    public async Task DeleteQuestAsync(int id)
    {
        await _questRepository.DeleteQuestAsync(id);
    }

    public async Task ApproveQuest(int loggedUserId, int questId)
    {
        var quest = await _questRepository.GetQuestByIdAsync(questId);

        quest.Status = QuestStatus.Approved;
        quest.ApprovedBy = loggedUserId;

        await _questRepository.SaveChangesAsync();
    }
    public async Task RejectQuest(int loggedUserId, int questId)
    {
        var quest = await _questRepository.GetQuestByIdAsync(questId);

        quest.Status = QuestStatus.Rejected;
        quest.ApprovedBy = loggedUserId;

        await _questRepository.SaveChangesAsync();
    }

    public async Task<bool> IsUserQuest(int loggedUserId, int questId)
    {
        var quest = await _questRepository.GetQuestByIdAsync(questId);

        return quest.CreatorId == loggedUserId;
    }
}
