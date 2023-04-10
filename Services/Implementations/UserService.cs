using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
    private readonly IBadgeRepository _badgeRepository;
    private readonly AppSettings _appSettings;

    public UserService(IMapper mapper, IUserRepository userRepository,
        IBadgeRepository badgeRepository, IOptions<AppSettings> appSettings)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
        _appSettings = appSettings.Value;
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
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userRepository.GetUserByEmailAndPassword(model.Email, model.Password);

        // return null if user not found
        if (user == null)
            throw new Exception("User not found");

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }



    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


}