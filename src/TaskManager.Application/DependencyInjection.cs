using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Team.CreateTeam;
using TaskManager.Application.Features.User.CreateUser;
using TaskManager.Application.Features.User.GetUser;
using TaskManager.Application.Features.User.DeleteUser;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateTeamCommandHandler, CreateTeamCommandHandler>();
        services.AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
        services.AddScoped<IGetUserQueryHandler, GetUserQueryHandler>();
        services.AddScoped<IDeleteUserCommandHandler, DeleteUserCommandHandler>();
        return services;
    }
}
