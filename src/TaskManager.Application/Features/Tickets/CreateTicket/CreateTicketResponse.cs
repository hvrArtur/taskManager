namespace TaskManager.Application.Features.Tickets.CreateTicket;

public sealed record CreateTicketResponse(Guid Id, string Name, string Description, Guid CreatorId, Guid TeamId, DateTime CreatedAtUtc);
