using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Features.Tickets.CreateTicket;
using TaskManager.Application.Features.Tickets.DeleteTicket;
using TaskManager.Application.Features.Tickets.GetTicket;
using TaskManager.Application.Features.Teams.AddUserToTeam;
using TaskManager.Application.Features.Teams.CreateTeam;
using TaskManager.Application.Features.Teams.DeleteTeam;
using TaskManager.Application.Features.Teams.GetTeam;
using TaskManager.Application.Features.Users.CreateUser;
using TaskManager.Application.Features.Users.DeleteUser;
using TaskManager.Application.Features.Users.GetUserByNickName;
using TaskManager.Application.Features.Users.GetUser;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateTicketCommandHandler, CreateTicketCommandHandler>();
        services.AddScoped<IDeleteTicketCommandHandler, DeleteTicketCommandHandler>();
        services.AddScoped<IGetTicketQueryHandler, GetTicketQueryHandler>();
        services.AddScoped<IAddUserToTeamCommandHandler, AddUserToTeamCommandHandler>();
        services.AddScoped<ICreateTeamCommandHandler, CreateTeamCommandHandler>();
        services.AddScoped<IDeleteTeamCommandHandler, DeleteTeamCommandHandler>();
        services.AddScoped<IGetTeamQueryHandler, GetTeamQueryHandler>();
        services.AddScoped<ICreateUserCommandHandler, CreateUserCommandHandler>();
        services.AddScoped<IGetUserQueryHandler, GetUserQueryHandler>();
        services.AddScoped<IGetUserByNickNameQueryHandler, GetUserByNickNameQueryHandler>();
        services.AddScoped<IDeleteUserCommandHandler, DeleteUserCommandHandler>();
        return services;
    }
}
