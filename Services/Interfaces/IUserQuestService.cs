using Repository.Models;
using Services.DTO;

namespace Services.Interfaces;

public interface IUserQuestService
{
    Task<IEnumerable<UserQuestDTO>> GetUserCompletedQuestsAsync(int loggedUserId);
    Task CompleteUserQuest(int loggedUserId, AddUserQuestDto userQuestDto);
}
