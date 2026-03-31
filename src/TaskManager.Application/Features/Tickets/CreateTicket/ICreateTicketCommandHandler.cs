namespace TaskManager.Application.Features.Tickets.CreateTicket;

public interface ICreateTicketCommandHandler
{
    Task<CreateTicketResponse> HandleAsync(CreateTicketCommand command, CancellationToken cancellationToken);
}
