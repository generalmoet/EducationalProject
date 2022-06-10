using Core.Application.Mapping;
using AutoMapper;
using Core.Application.Users.Commands;

namespace Presentation.WebUI.Models;

public class CreateUserDto : IMapWith<CreateUserCommand>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDto, CreateUserCommand>()
            .ForMember(userCommand => userCommand.Name, opt => opt.MapFrom(userDto => userDto.Name))
            .ForMember(userCommand => userCommand.Surname, opt => opt.MapFrom(userDto => userDto.Surname))
            .ForMember(userCommand => userCommand.Birthday, opt => opt.MapFrom(userDto => userDto.Birthday))
            .ForMember(userCommand => userCommand.Email, opt => opt.MapFrom(userDto => userDto.Email));
    }
}
