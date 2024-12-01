// Services/BetService.cs
using Microsoft.EntityFrameworkCore;

public class BetService
{
    private readonly ApplicationDbContext _context;

    public BetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bet> PlaceBet(int userId, string type, decimal amount, decimal odds)
    {
        var potential = amount * odds;
        var bet = new Bet
        {
            UserId = userId,
            Type = type,
            Amount = amount,
            Odds = odds,
            Potential = potential,
            Status = "pending",
            Date = DateTime.UtcNow,
            IsValidated = false
        };

        _context.Bets.Add(bet);
        await _context.SaveChangesAsync();

        // Restar el monto apostado de la wallet del usuario
        await UpdateUserWallet(userId, -amount);

        return bet;
    }

    public async Task<Bet> UpdateBetStatus(int betId)
    {
        var bet = await _context.Bets.FindAsync(betId);
        if (bet != null && !bet.IsValidated)
        {
            // Randomizar el estado de la apuesta
            var random = new Random();
            var status = random.Next(2) == 0 ? "won" : "lost";
            bet.Status = status;
            bet.IsValidated = true;

            if (status == "won")
            {
                await UpdateUserWallet(bet.UserId, bet.Potential);
            }

            await _context.SaveChangesAsync();
        }
        return bet;
    }

    public async Task<List<Bet>> GetBetsByUser(int userId)
    {
        return await _context.Bets
            .Where(bet => bet.UserId == userId)
            .ToListAsync();
    }
    private async Task UpdateUserWallet(int userId, decimal amount)
    {
        // Llama al procedimiento almacenado para actualizar la wallet del usuario
        await _context.Database.ExecuteSqlRawAsync("CALL UpdateUserWallet({0}, {1})", userId, amount);
    }
}