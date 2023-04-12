using Services.DTO;

namespace Services.Interfaces;

public interface IQuestService
{
    Task<IEnumerable<UpdateQuestDTO>> GetAllQuestsAsync();
    Task<UpdateQuestDTO> GetQuestByIdAsync(int id);
    Task CreateQuestAsync(AddQuestDTO quest);
    Task UpdateQuestAsync(UpdateQuestDTO quest);
    Task DeleteQuestAsync(int id);
    Task ApproveQuest(int loggedUserId, int questId);
    Task RejectQuest(int loggedUserId, int questId);
    Task<bool> IsUserQuest(int loggedUserId, int questId);
}
