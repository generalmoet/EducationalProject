using Core.Application.Interfaces;
using MediatR;

namespace Core.Application.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserDbContext _context;

    public UpdateUserCommandHandler(IUserDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var changingUser = _context.Users.Find(new object[] { request.Id });

        if (changingUser == null) throw new Exception("User not found");

        changingUser.Name = request.Name;
        changingUser.Surname = request.Surname;
        changingUser.Birthday = request.Birthday;
        changingUser.Email = request.Email;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
