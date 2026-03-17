using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Teams.CreateTeam;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateTeamCommandHandler, CreateTeamCommandHandler>();
        return services;
    }
}
