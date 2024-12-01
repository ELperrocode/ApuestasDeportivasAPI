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
        var bet = await _betService.PlaceBet(placeBetDto.UserId, placeBetDto.Type, placeBetDto.Amount, placeBetDto.Odds);
        return Ok(bet);
    }

      [HttpPost("validate/{betId}")]
    public async Task<ActionResult<Bet>> ValidateBet(int betId)
    {
        var bet = await _betService.UpdateBetStatus(betId);
        if (bet == null)
        {
            return NotFound();
        }
        return Ok(bet);
    }

        [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<Bet>>> GetBetsByUser(int userId)
    {
        var bets = await _betService.GetBetsByUser(userId);
        if (bets == null || bets.Count == 0)
        {
            return NotFound();
        }
        return Ok(bets);
    }


}

public class PlaceBetDto
{
    public int UserId { get; set; }
    public string Type { get; set; } 
    public decimal Amount { get; set; }
    public decimal Odds { get; set; }
}

public class UpdateBetStatusDto
{
    public int BetId { get; set; }
    public string Status { get; set; } // 'pending', 'placed', 'won', 'lost'
}