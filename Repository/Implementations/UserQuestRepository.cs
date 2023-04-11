using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class UserQuestRepository : IUserQuestRepository
{
    private readonly BlueDbContext _dbContext;

    public UserQuestRepository(BlueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserQuest>> GetUserCompletedQuestsAsync(int loggedUserId)
    {
        return await _dbContext.UserQuests.Where(x => x.UserId == loggedUserId).ToListAsync();
    }

    public async Task<UserQuest> GetUserQuestByUserIdAndQuestIdAsync(int loggedUserId, int QuestId)
    {
        var Quest = await _dbContext.UserQuests.FirstOrDefaultAsync(q => q.UserId == loggedUserId && q.QuestId == QuestId);
        if (Quest == null)
        {
            throw new Exception("UserQuest not found");
        }
        return Quest;
    }

    public async Task DeleteUserQuest(UserQuest userQuest)
    {
        var dbUserQuest = await GetUserQuestByUserIdAndQuestIdAsync(userQuest.UserId, userQuest.QuestId);

        _dbContext.UserQuests.Remove(dbUserQuest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveUserQuest(UserQuest userQuest)
    {
        _dbContext.UserQuests.Add(userQuest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
