using Core.Application.Mapping;
using AutoMapper;
using Core.Domain.Models;
using MediatR;

namespace Core.Application.Users.Queries;

public class UserListDto : IMapWith<User>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserListDto>()
            .ForMember(userDto => userDto.Name, opt => opt.MapFrom(user => user.Name))
            .ForMember(userDto => userDto.Surname, opt => opt.MapFrom(user => user.Surname))
            .ForMember(userDto => userDto.Birthday, opt => opt.MapFrom(user => user.Birthday));
    }

}
