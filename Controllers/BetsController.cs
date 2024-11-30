// Controllers/BetsController.cs
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class BetsController : ControllerBase
{
    private readonly BetService _betService;

    public BetsController(BetService betService)
    {
        _betService = betService;
    }

    [HttpPost("place")]
    public async Task<ActionResult<Bet>> PlaceBet([FromBody] PlaceBetDto placeBetDto)
    {
        var bet = await _betService.PlaceBet(placeBetDto.UserId, placeBetDto.MatchId, placeBetDto.Type, placeBetDto.Amount, placeBetDto.Odds);
        return Ok(bet);
    }

    [HttpPost("update-status")]
    public async Task<ActionResult<Bet>> UpdateBetStatus([FromBody] UpdateBetStatusDto updateBetStatusDto)
    {
        var bet = await _betService.UpdateBetStatus(updateBetStatusDto.BetId, updateBetStatusDto.Status);
        if (bet == null)
        {
            return NotFound();
        }
        return Ok(bet);
    }
}

public class PlaceBetDto
{
    public int UserId { get; set; }
    public int MatchId { get; set; }
    public string Type { get; set; } // 'home', 'draw', 'away'
    public decimal Amount { get; set; }
    public decimal Odds { get; set; }
}

public class UpdateBetStatusDto
{
    public int BetId { get; set; }
    public string Status { get; set; } // 'pending', 'placed', 'won', 'lost'
}