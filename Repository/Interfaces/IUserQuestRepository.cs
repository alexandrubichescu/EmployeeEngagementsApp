using Repository.Models;

namespace Repository.Interfaces;

public interface IUserQuestRepository
{
    Task<UserQuest> GetUserQuestByUserIdAndQuestIdAsync(int loggedUserId, int questId);
    Task<IEnumerable<UserQuest>> GetUserCompletedQuestsAsync(int loggedUserId);

    Task DeleteUserQuest(UserQuest userQuest);

    Task SaveUserQuest(UserQuest userQuest);

    Task SaveChangesAsync();
}
