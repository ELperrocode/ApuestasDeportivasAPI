// Services/BetService.cs
public class BetService
{
    private readonly ApplicationDbContext _context;

    public BetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bet> PlaceBet(int userId, int matchId, string type, decimal amount, decimal odds)
    {
        var potential = amount * odds;
        var bet = new Bet
        {
            MatchId = matchId,
            Type = type,
            Amount = amount,
            Odds = odds,
            Potential = potential,
            Status = "pending",
            Date = DateTime.UtcNow
        };

        _context.Bets.Add(bet);
        await _context.SaveChangesAsync();
        return bet;
    }

    public async Task<Bet> UpdateBetStatus(int betId, string status)
    {
        var bet = await _context.Bets.FindAsync(betId);
        if (bet != null)
        {
            bet.Status = status;
            await _context.SaveChangesAsync();
        }
        return bet;
    }
}
