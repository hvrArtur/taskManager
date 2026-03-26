using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Features.Team.CreateTeam;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("teams")]
public sealed class TeamsController(ICreateTeamCommandHandler createTeamCommandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTeamCommand(request.Name, request.OwnerId);

        try
        {
            var result = await createTeamCommandHandler.HandleAsync(command, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (ConflictException ex)
        {
            return Conflict(new { error = ex.Message });
        }
    }
}

public sealed record CreateTeamRequest(string Name, Guid OwnerId);
