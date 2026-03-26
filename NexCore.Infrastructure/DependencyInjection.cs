using Microsoft.Extensions.DependencyInjection;
using NexCore.Application.Common.Interfaces;
using NexCore.Infrastructure.Common.Services;

namespace NexCore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Email
        // File Storage

        return services;
    }
}