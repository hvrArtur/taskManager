namespace TaskManager.Application.Features.Tickets.GetTicket;

public sealed record GetTicketResponse(
    Guid Id,
    string Name,
    string Description,
    Guid CreatorId,
    string CreatorNickName,
    Guid TeamId,
    string TeamName,
    DateTime CreatedAtUtc);
