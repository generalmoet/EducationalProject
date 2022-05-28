using Core.Application.Interfaces;
using Core.Domain.Models;

namespace Application.Users.Commands.CreateUserCommand;

public class CreateUserCommand
{
    private readonly IUserDbContext _context;

    public CreateUserCommand(IUserDbContext context)
    {
        _context = context;
    }

    public async Task CreateUser(string name, string surname, DateTime birthday, string email, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = name,
            Surname = surname,
            Birthday = birthday,
            Email = email
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateUser(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user);
    }
}
