using Core.Application.Interfaces;
using Core.Domain.Models;

namespace Core.Application.Users.Queries.GetUsersDetail;

public class GetUsersQuery
{
    private readonly IUserDbContext _context;

    public GetUsersQuery(IUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersList()
    {
        var users = _context.Users.ToList<User>();

        if (users == null) throw new Exception("No users");

        return users;
    }
}
