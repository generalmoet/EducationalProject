using MediatR;

namespace Core.Application.Users.Queries;

public class GetUserQuery : IRequest<UserViewModel>
{
    public int Id { get; set; }
}
