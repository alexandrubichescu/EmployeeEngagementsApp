using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implementations;

public class QuestRepository : IQuestRepository
{
    private readonly BlueDbContext _dbContext;

    public QuestRepository(BlueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Quest>> GetAllQuestsAsync()
    {
        return await _dbContext.Quests.ToListAsync();
    }

    public async Task<Quest> GetQuestByIdAsync(int id)
    {
        var quest = await _dbContext.Quests.FirstOrDefaultAsync(q => q.Id == id);
        if (quest == null)
        {
            throw new ArgumentException("Quest not found", nameof(id));
        }
        return quest;
    }

    public async Task CreateQuestAsync(Quest quest)
    {
        _dbContext.Quests.Add(quest);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteQuestAsync(int id)
    {
        var quest = await GetQuestByIdAsync(id);
        if (quest != null)
        {
            _dbContext.Quests.Remove(quest);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
