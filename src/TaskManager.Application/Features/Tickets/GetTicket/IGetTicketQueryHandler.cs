namespace TaskManager.Application.Features.Tickets.GetTicket;

public interface IGetTicketQueryHandler
{
    Task<GetTicketResponse> HandleAsync(GetTicketQuery query, CancellationToken cancellationToken);
}
