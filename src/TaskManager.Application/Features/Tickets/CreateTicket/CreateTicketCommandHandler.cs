using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Tickets.CreateTicket;

public sealed class CreateTicketCommandHandler(
    IUserRepository userRepository,
    ITeamRepository teamRepository,
    ITicketRepository ticketRepository) : ICreateTicketCommandHandler
{
    public async Task<CreateTicketResponse> HandleAsync(CreateTicketCommand command, CancellationToken cancellationToken)
    {
        var creator = await userRepository.GetByIdAsync(command.CreatorId, cancellationToken);
        var team = await teamRepository.GetByIdAsync(command.TeamId, cancellationToken);

        if (creator is null || team is null || !team.HasMember(command.CreatorId))
            throw new ConflictException("User is not a member of the team.");

        var ticket = new Ticket(command.Name, command.Description, creator, team);
        await ticketRepository.AddAsync(ticket, cancellationToken);

        return new CreateTicketResponse(ticket.Id, ticket.Name, ticket.Description, ticket.CreatorId, ticket.TeamId, ticket.CreatedAt);
    }
}
