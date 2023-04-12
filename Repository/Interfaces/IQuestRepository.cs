using Repository.Models;

namespace Repository.Interfaces;

public interface IQuestRepository
{
    Task<IEnumerable<Quest>> GetAllQuestsAsync();
    Task<Quest> GetQuestByIdAsync(int id);
    Task CreateQuestAsync(Quest quest);
    Task DeleteQuestAsync(int id);
    Task SaveChangesAsync();
}
