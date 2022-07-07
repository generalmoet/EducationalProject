using FluentValidation;

namespace Core.Application.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty().GreaterThan(-1);
        RuleFor(command => command.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(20);
        RuleFor(command => command.Name).NotEmpty().NotNull().MaximumLength(20);
        RuleFor(command => command.Surname).NotEmpty().NotNull().MaximumLength(20);
        RuleFor(command => command.Birthday).NotEmpty();
    }
}