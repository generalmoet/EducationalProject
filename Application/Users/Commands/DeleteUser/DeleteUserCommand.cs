using MediatR;

namespace Core.Application.Users.Commands;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}
