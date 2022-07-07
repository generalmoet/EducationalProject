using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Application.Behaviours;
using FluentValidation;
using MediatR;

namespace Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        return services;
    }
}
