using Core.Application.Interfaces;

namespace Core.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand
{
    private readonly IUserDbContext _context;

    public DeleteUserCommand(IUserDbContext context)
    {
        _context = context;
    }

    public async Task DeleteUser(int Id, CancellationToken cancellationToken)
    {
        var user = _context.Users.Find(new object[] { Id });

        if (user == null) throw new Exception("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
