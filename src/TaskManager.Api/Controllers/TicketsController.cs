using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tickets.CreateTicket;
using TaskManager.Application.Features.Tickets.DeleteTicket;
using TaskManager.Application.Features.Tickets.GetTicket;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public sealed class TicketsController(
    ICreateTicketCommandHandler createTicketCommandHandler,
    IGetTicketQueryHandler getTicketQueryHandler,
    IDeleteTicketCommandHandler deleteTicketCommandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTicketCommand(request.Name, request.Description, request.CreatorId, request.TeamId);
        var result = await createTicketCommandHandler.HandleAsync(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { ticketId = result.Id }, result);
    }

    [HttpGet("{ticketId:guid}")]
    public async Task<IActionResult> Get(Guid ticketId, CancellationToken cancellationToken)
    {
        var query = new GetTicketQuery(ticketId);
        var result = await getTicketQueryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{ticketId:guid}")]
    public async Task<IActionResult> Delete(Guid ticketId, CancellationToken cancellationToken)
    {
        var command = new DeleteTicketCommand(ticketId);
        await deleteTicketCommandHandler.HandleAsync(command, cancellationToken);
        return NoContent();
    }
}

public sealed record CreateTicketRequest(string Name, string Description, Guid CreatorId, Guid TeamId);
