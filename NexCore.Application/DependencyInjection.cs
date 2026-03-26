using FluentValidation;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace NexCore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var currentAssembly = typeof(DependencyInjection).Assembly;

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => { module.RegisterFromAssembly(currentAssembly); });
            liteBus.AddQueryModule(module => { module.RegisterFromAssembly(currentAssembly); });
        });

        services.AddValidatorsFromAssembly(currentAssembly);

        return services;
    }
}