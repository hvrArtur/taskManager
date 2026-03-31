namespace TaskManager.Application.Features.Tickets.CreateTicket;

public sealed record CreateTicketCommand(string Name, string Description, Guid CreatorId, Guid TeamId);
