using MediatR;

namespace Core.Application.Users.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
}
