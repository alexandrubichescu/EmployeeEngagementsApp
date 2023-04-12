using AutoMapper;
using Repository.Models;
using Services.DTO;

namespace Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UpdateUserDTO>().ReverseMap();
        CreateMap<User, AddUserDTO>().ReverseMap();
        CreateMap<Quest, UpdateQuestDTO>().ReverseMap();
        CreateMap<Quest, AddQuestDTO>().ReverseMap();
        CreateMap<UserQuest, UserQuestDTO>().ReverseMap();
    }
}
