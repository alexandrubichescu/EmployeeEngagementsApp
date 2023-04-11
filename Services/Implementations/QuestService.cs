using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

    public async Task ApproveQuest(int loggedUserId, int QuestId)
    {
        var Quest = await _questRepository.GetQuestByIdAsync(QuestId);

        Quest.Status = QuestStatus.Approved;
        Quest.ApprovedBy = loggedUserId;

        await _questRepository.SaveChangesAsync();
    }
    public async Task RejectQuest(int loggedUserId, int QuestId)
    {
        var Quest = await _questRepository.GetQuestByIdAsync(QuestId);

        Quest.Status = QuestStatus.Rejected;
        Quest.ApprovedBy = loggedUserId;

        await _questRepository.SaveChangesAsync();
    }

    public async Task<bool> IsUserQuest(int loggedUserId, int QuestId)
    {
        var Quest = await _questRepository.GetQuestByIdAsync(QuestId);

        return Quest.CreatorId == loggedUserId;
    }
}
