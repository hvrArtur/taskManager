using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Teams.CreateTeam;
using TaskManager.Application.Features.Users.CreateUser;
using TaskManager.Application.Features.Users.GetUser;
using TaskManager.Application.Features.Users.DeleteUser;

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
