// Services/BetService.cs
using Microsoft.EntityFrameworkCore;

public class BetService
{
    private readonly ApplicationDbContext _context;

    public BetService(ApplicationDbContext context)
    {
        _context = context;
    }

  public async Task<(Bet, decimal)> PlaceBet(int userId, string type, decimal amount, decimal odds)
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

        // Obtener el saldo actualizado del usuario
        var user = await _context.Users.FindAsync(userId);
        var updatedBalance = user.Wallet;

        return (bet, updatedBalance);
    }
    
 public async Task<(List<Bet>, decimal)> UpdateBetStatus(int userId)
    {
        var bets = await _context.Bets
            .Where(bet => bet.UserId == userId && !bet.IsValidated)
            .ToListAsync();

        if (bets != null && bets.Count > 0)
        {
            var random = new Random();
            foreach (var bet in bets)
            {
                // Randomizar el estado de la apuesta
                var status = random.Next(2) == 0 ? "won" : "lost";
                bet.Status = status;
                bet.IsValidated = true;

                if (status == "won")
                {
                    await UpdateUserWallet(bet.UserId, bet.Potential);
                }
            }

            await _context.SaveChangesAsync();

            // Obtener el saldo actualizado del usuario
            var user = await _context.Users.FindAsync(userId);
            var updatedBalance = user.Wallet;

            return (bets, updatedBalance);
        }
        return (new List<Bet>(), 0);
    }

    public async Task<List<Bet>> GetBetsByUser(int userId)
    {
        return await _context.Bets
            .Where(bet => bet.UserId == userId)
            .ToListAsync();
    }

       public async Task<decimal> GetUserBalance(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        return user?.Wallet ?? 0;
    }
    private async Task UpdateUserWallet(int userId, decimal amount)
    {
        // Llama al procedimiento almacenado para actualizar la wallet del usuario
        await _context.Database.ExecuteSqlRawAsync("CALL UpdateUserWallet({0}, {1})", userId, amount);
    }
}