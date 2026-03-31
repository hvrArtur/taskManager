namespace TaskManager.Application.Features.Tickets.DeleteTicket;

public interface IDeleteTicketCommandHandler
{
    Task HandleAsync(DeleteTicketCommand command, CancellationToken cancellationToken);
}
