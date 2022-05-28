using Core.Application.Interfaces;
using Core.Domain.Models;

namespace Core.Application.Users.Queries.GetUserDetails;

public class GetUserQuery
{
    private readonly IUserDbContext _context;

    public GetUserQuery(IUserDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUser(int Id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == Id);

        if (user == null) throw new Exception("User not found");


        return (User)user;
    }
}
