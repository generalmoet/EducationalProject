using MediatR;

namespace Core.Application.Users.Commands;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
