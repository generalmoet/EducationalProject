using FluentValidation;

namespace Core.Application.Users.Queries;

public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(query => query.Id).NotEmpty();
    }
}