﻿using Repository.Models;
using Services.DTO;

namespace Services.Interfaces;

public interface IQuestService
{
    Task<IEnumerable<QuestDTO>> GetAllQuestsAsync();
    Task<QuestDTO> GetQuestByIdAsync(int id);
    Task CreateQuestAsync(QuestDTO quest);
    Task UpdateQuestAsync(int id, QuestDTO quest);
    Task DeleteQuestAsync(int id);
}