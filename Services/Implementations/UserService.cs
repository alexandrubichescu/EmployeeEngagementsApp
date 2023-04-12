using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Repository.Interfaces;
using Repository.Models;
using Services.Auth;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtUtils _jwtUtils;
    private readonly IBadgeRepository _badgeRepository;

    public UserService(IMapper mapper, IUserRepository userRepository,
        IBadgeRepository badgeRepository, IJwtUtils jwtUtils)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
        _jwtUtils = jwtUtils;
    }


    public async Task<int> AddUserAsync(AddUserDTO UserDTO)
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

    public async Task<List<UpdateUserDTO>> GetAllUsersAsync()
    {
        return _mapper.Map<List<UpdateUserDTO>>(await _userRepository.GetAllUsersAsync());
    }

    public async Task<UpdateUserDTO> GetUserByIdAsync(int id)
    {
        return _mapper.Map<UpdateUserDTO>(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task UpdateUserAsync(UpdateUserDTO userDTO)
    {
        var user = await _userRepository.GetUserByIdAsync(userDTO.Id);
        if (user == null)
            throw new Exception("User could not be found");

        user.Email = userDTO.Email;
        user.FirstName = userDTO.FirstName;
        user.Points = userDTO.Points;
        user.LastName = userDTO.LastName;
        user.Role = userDTO.Role;
        user.Password = userDTO.Password;

        await _userRepository.SaveChangesAsync();
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userRepository.GetUserByEmailAndPassword(model.Email, model.Password);

        if (user is null)
            throw new Exception("Invalid user");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, jwtToken);
    }

}