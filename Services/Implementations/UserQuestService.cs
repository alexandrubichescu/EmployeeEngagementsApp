using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Implementations;
using Repository.Interfaces;
using Repository.Models;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations;

public class UserQuestService : IUserQuestService
{
    private readonly IQuestRepository _QuestRepository;
    private readonly IUserQuestRepository _userQuestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBadgeService _badgeService;

    public UserQuestService(
        IQuestRepository QuestRepository, 
        IUserQuestRepository userQuestRepository, 
        IUserRepository userRepository,
        IBadgeService badgeService)
    {
        _QuestRepository = QuestRepository;
        _userQuestRepository = userQuestRepository;
        _userRepository = userRepository;
        _badgeService = badgeService;
    }

    public async Task CompleteUserQuest(int loggedUserId, AddUserQuestDto userQuestDto)
    {
        var existingQuest = await _QuestRepository.GetQuestByIdAsync(userQuestDto.QuestId);
        if (existingQuest == null)
            throw new Exception($"Quest with id {userQuestDto.QuestId} not found.");

        var userQuest = new UserQuest()
        {
            QuestId = existingQuest.Id,
            UserId = loggedUserId,
            Comments = userQuestDto.Comments,
            ImageUrl = userQuestDto.ImageUrl,
            ProofOfCompletion = userQuestDto.ProofOfCompletion
        };

        await _userQuestRepository.SaveUserQuest(userQuest);

        // update user points because a Quest was completed
        var user = await _userRepository.GetFullUserByIdAsync(loggedUserId);
        user!.Points += existingQuest.Points;
        
        // check if user should receive a Badge
        var latestBadges = await _badgeService.GetLatestUserBadges(user, user.Points);
        if (latestBadges.Count > 0)
            user.Badges.AddRange(latestBadges);

        await _userRepository.SaveChangesAsync();
    }


    public Task<UserQuestDto> GetUserQuestAsync(int loggedUserId, int QuestId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserQuestDto>> GetUserCompletedQuestsAsync(int loggedUserId)
    {
        var Quests = await _userQuestRepository.GetUserCompletedQuestsAsync(loggedUserId);

        // mapper to userQuests to UserQuestDto
        throw new NotImplementedException();
    }

    public Task DeleteUserQuest(int loggedUserId, int QuestId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserQuest(AddUserQuestDto userQuest)
    {
        throw new NotImplementedException();
    }

}
