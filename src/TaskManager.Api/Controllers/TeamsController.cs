using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Teams.CreateTeam;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("teams")]
public sealed class TeamsController(ICreateTeamCommandHandler createTeamCommandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTeamCommand(request.Name, request.OwnerId);
        var result = await createTeamCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(result);
    }
}

public sealed record CreateTeamRequest(string Name, Guid OwnerId);
