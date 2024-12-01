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
    public async Task<ActionResult<BetResponseDto>> PlaceBet([FromBody] PlaceBetDto placeBetDto)
    {
        var (bet, updatedBalance) = await _betService.PlaceBet(placeBetDto.UserId, placeBetDto.Type, placeBetDto.Amount, placeBetDto.Odds);
        var response = new BetResponseDto
        {
            Bet = bet,
            UpdatedBalance = updatedBalance
        };
        return Ok(response);
    }

     [HttpPost("validate/{userId}")]
    public async Task<ActionResult<BetResponseDto>> ValidateBets(int userId)
    {
        var (bets, updatedBalance) = await _betService.UpdateBetStatus(userId);
        if (bets == null || bets.Count == 0)
        {
            return NotFound();
        }
        var response = new BetResponseDto
        {
            Bets = bets,
            UpdatedBalance = updatedBalance
        };
        return Ok(response);
    }

        [HttpGet("user/{userId}/balance")]
    public async Task<ActionResult<decimal>> GetUserBalance(int userId)
    {
        var balance = await _betService.GetUserBalance(userId);
        return Ok(balance);
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
public class BetResponseDto
{
    public Bet Bet { get; set; }
    public List<Bet> Bets { get; set; }
    public decimal UpdatedBalance { get; set; }
}

public class UpdateBetStatusDto
{
    public int BetId { get; set; }
    public string Status { get; set; } // 'pending', 'placed', 'won', 'lost'
}