using Core.Application.Mapping;
using AutoMapper;
using Core.Application.Users.Commands;

namespace Presentation.WebUI.Models;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(userCommand => userCommand.Id, opt => opt.MapFrom(userDto => Id))
            .ForMember(userCommand => userCommand.Name, opt => opt.MapFrom(userDto => Name))
            .ForMember(userCommand => userCommand.Surname, opt => opt.MapFrom(userDto => Surname))
            .ForMember(userCommand => userCommand.Birthday, opt => opt.MapFrom(userDto => Birthday))
            .ForMember(userCommand => userCommand.Email, opt => opt.MapFrom(userDto => Email));
    }
}
