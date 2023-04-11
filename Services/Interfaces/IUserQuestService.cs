using Repository.Models;
using Services.DTO;

namespace Services.Interfaces;

public interface IUserQuestService
{
    Task<UserQuestDto> GetUserQuestAsync(int loggedUserId, int QuestId);
    Task<IEnumerable<UserQuestDto>> GetUserCompletedQuestsAsync(int loggedUserId);

    Task DeleteUserQuest(int loggedUserId, int QuestId);

    Task CompleteUserQuest(int loggedUserId, AddUserQuestDto userQuestDto);
    Task UpdateUserQuest(AddUserQuestDto userQuest);
}
