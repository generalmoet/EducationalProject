using Core.Application.Interfaces;
using Core.Domain.Models;
using MediatR;

namespace Core.Application.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserDbContext _context;

    public CreateUserCommandHandler(IUserDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = request.Name,
            Surname = request.Surname,
            Birthday = request.Birthday,
            Email = request.Email
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
