using MediatR;

namespace Core.Application.Users.Commands;

public class CreateUserCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
}
