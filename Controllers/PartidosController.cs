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

    [HttpGet("{leagueId}")]
    public async Task<ActionResult<IEnumerable<Partido>>> GetPartidos(string leagueId)
    {
        var partidos = await _externalApiService.GetPartidos(leagueId);
        foreach (var partido in partidos)
        {
            partido.Odds = GenerateRandomOdds();
        }
        return Ok(partidos);
    }

    private decimal GenerateRandomOdds()
    {
        var random = new Random();
        return (decimal)(random.NextDouble() * 2 + 1); 
    }
}
