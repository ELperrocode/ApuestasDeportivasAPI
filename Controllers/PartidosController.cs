using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PartidosController : ControllerBase
{
    private readonly ExternalApiService _externalApiService;

    public PartidosController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet("leagues")]
    public async Task<ActionResult<IEnumerable<Liga>>> GetLeagues()
    {
        var leagues = await _externalApiService.GetLeagues();
        return Ok(leagues);
    }

    [HttpGet("upcomingMatches/{leagueId}")]
    public async Task<ActionResult<IEnumerable<Partido>>> GetUpcomingMatches(string leagueId)
    {
        var matches = await _externalApiService.GetUpcomingMatches(leagueId);
        return Ok(matches);
    }

    private decimal GenerateRandomOdds()
    {
        var random = new Random();
        return (decimal)(random.NextDouble() * 2 + 1); 
    }
}