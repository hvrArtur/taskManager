using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Teams.AddUserToTeam;
using TaskManager.Application.Features.Teams.CreateTeam;
using TaskManager.Application.Features.Teams.DeleteTeam;
using TaskManager.Application.Features.Teams.GetTeam;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/teams")]
public sealed class TeamsController(
    ICreateTeamCommandHandler createTeamCommandHandler,
    IGetTeamQueryHandler getTeamQueryHandler,
    IDeleteTeamCommandHandler deleteTeamCommandHandler,
    IAddUserToTeamCommandHandler addUserToTeamCommandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTeamCommand(request.Name, request.OwnerId);
        var result = await createTeamCommandHandler.HandleAsync(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { teamId = result.Id }, result);
    }

    [HttpGet("{teamId:guid}")]
    public async Task<IActionResult> Get(Guid teamId, CancellationToken cancellationToken)
    {
        var query = new GetTeamQuery(teamId);
        var result = await getTeamQueryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{teamId:guid}")]
    public async Task<IActionResult> Delete(Guid teamId, CancellationToken cancellationToken)
    {
        var command = new DeleteTeamCommand(teamId);
        await deleteTeamCommandHandler.HandleAsync(command, cancellationToken);
        return NoContent();
    }

    [HttpPost("{teamId:guid}/members")]
    public async Task<IActionResult> AddMember(Guid teamId, [FromBody] AddTeamMemberRequest request, CancellationToken cancellationToken)
    {
        var command = new AddUserToTeamCommand(teamId, request.UserId);
        var result = await addUserToTeamCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(result);
    }
}

public sealed record CreateTeamRequest(string Name, Guid OwnerId);
public sealed record AddTeamMemberRequest(Guid UserId);
