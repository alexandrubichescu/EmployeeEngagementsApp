using AutoMapper;
using Repository.Models;
using Services.DTO;

namespace Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
    }
}
