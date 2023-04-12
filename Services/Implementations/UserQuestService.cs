using AutoMapper;
using Repository.Interfaces;
using Repository.Models;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations;

public class UserQuestService : IUserQuestService
{
    private readonly IQuestRepository _questRepository;
    private readonly IUserQuestRepository _userQuestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBadgeService _badgeService;
    private readonly IMapper _mapper;

    public UserQuestService(
        IQuestRepository questRepository,
        IUserQuestRepository userQuestRepository,
        IUserRepository userRepository,
        IBadgeService badgeService,
        IMapper mapper = null)
    {
        _questRepository = questRepository;
        _userQuestRepository = userQuestRepository;
        _userRepository = userRepository;
        _badgeService = badgeService;
        _mapper = mapper;
    }

    public async Task CompleteUserQuest(int loggedUserId, AddUserQuestDto userQuestDto)
    {
        var existingQuest = await _questRepository.GetQuestByIdAsync(userQuestDto.QuestId);
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
        var latestBadges = await _badgeService.GetLatestUserBadgesAsync(user, user.Points);
        if (latestBadges.Count > 0)
            user.Badges.AddRange(latestBadges);

        await _userRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserQuestDTO>> GetUserCompletedQuestsAsync(int loggedUserId)
    {
        var quests = await _userQuestRepository.GetUserCompletedQuestsAsync(loggedUserId);

        return _mapper.Map<IEnumerable<UserQuestDTO>>(quests);
                
    }


}
