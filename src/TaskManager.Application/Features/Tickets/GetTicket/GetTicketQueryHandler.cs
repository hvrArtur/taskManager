using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Tickets.GetTicket;

public sealed class GetTicketQueryHandler(ITicketRepository ticketRepository) : IGetTicketQueryHandler
{
    public async Task<GetTicketResponse> HandleAsync(GetTicketQuery query, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetByIdAsync(query.TicketId, cancellationToken);
        if (ticket is null)
            throw new NotFoundException($"Ticket '{query.TicketId}' was not found.");

        return new GetTicketResponse(
            ticket.Id,
            ticket.Name,
            ticket.Description,
            ticket.CreatorId,
            ticket.Creator.NickName,
            ticket.TeamId,
            ticket.Team.Name,
            ticket.CreatedAt);
    }
}
