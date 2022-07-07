using FluentValidation;

namespace Core.Application.Users.Commands;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}