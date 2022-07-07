using FluentValidation;

namespace Core.Application.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(20);
        RuleFor(command => command.Name).NotEmpty().NotNull().MaximumLength(20);
        RuleFor(command => command.Surname).NotEmpty().NotNull().MaximumLength(20);
        RuleFor(command => command.Birthday).NotEmpty();
    }
}