// Services/BetService.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BetService
{
    private readonly ApplicationDbContext _context;

    public BetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bet> PlaceBet(int userId, int partidoId, decimal amount)
    {
        var bet = new Bet { UserId = userId, PartidoId = partidoId, Amount = amount, Date = DateTime.Now };
        _context.Bets.Add(bet);
        await _context.SaveChangesAsync();
        return bet;
    }
}
