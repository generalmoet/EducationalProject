using Core.Application.Interfaces;
using Core.Domain.Models;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommand
{
    private readonly IUserDbContext _context;

    public UpdateUserCommand(IUserDbContext context)
    {
        _context = context;
    }

    public async Task Update(int Id, User user, CancellationToken cancellationToken)
    {
        var changingUser = _context.Users.Find(new object[] { Id });

        if (user == null) throw new Exception("User not found");

        changingUser.Name = user.Name;
        changingUser.Surname = user.Surname;
        changingUser.Birthday = user.Birthday;
        changingUser.Email = user.Email;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
