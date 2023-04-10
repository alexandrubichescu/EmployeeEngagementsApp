using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IBadgeRepository _badgeRepository;

    public UserService(IMapper mapper, IUserRepository userRepository, IBadgeRepository badgeRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
    }

    public async Task<int> AddUserAsync(UserDTO UserDTO)
    {
        var user = _mapper.Map<User>(UserDTO);
        await _userRepository.AddUserAsync(user);
        return user.Id;
    }


    public async Task AddUserBadgeAsync(int id, int badgeId)
    {
        var user = await _userRepository.GetFullUserByIdAsync(id);
        var badge = await _badgeRepository.GetBadgeByIdAsync(badgeId);

        if (user == null)
            throw new Exception("User not found");
        if (badge == null)
            throw new Exception("Badge not found");

        user.Badges?.Add(badge);

        await _userRepository.SaveChangesAsync();
    }

    public async Task AddUserPointsAsync(int id, int points)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");

        user.Points += points;

        await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            return await _userRepository.DeleteUserAsync(user);
        }
        else
            return false;
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        return _mapper.Map<List<UserDTO>>(await _userRepository.GetAllUsersAsync());
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        return _mapper.Map<UserDTO>(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task<bool> UpdateUserAsync(UserDTO UserDTO)
    {
        var user = await _userRepository.GetUserByIdAsync(UserDTO.Id);
        if (user != null)
        {
            user = _mapper.Map(UserDTO, user);
            return await _userRepository.UpdateUserAsync(user);
        }
        return false;
    }
}