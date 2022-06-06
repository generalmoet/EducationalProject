using MediatR;

namespace Core.Application.Users.Queries;

public class GetUsersQuery : IRequest<UserListVm>{ }
