using MediatR;

namespace Core.Application.Users.Queries;

public class GetUserQuery : IRequest<UserVm>
{
    public int Id { get; set; }
}
