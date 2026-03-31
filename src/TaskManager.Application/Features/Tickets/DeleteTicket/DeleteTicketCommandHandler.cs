using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Tickets.DeleteTicket;

public sealed class DeleteTicketCommandHandler(ITicketRepository ticketRepository) : IDeleteTicketCommandHandler
{
    public async Task HandleAsync(DeleteTicketCommand command, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.GetByIdAsync(command.TicketId, cancellationToken);
        if (ticket is null)
            throw new NotFoundException($"Ticket '{command.TicketId}' was not found.");

        await ticketRepository.DeleteAsync(ticket, cancellationToken);
    }
}
