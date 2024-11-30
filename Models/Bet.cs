// Models/Bet.cs
public class Bet
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public string Type { get; set; } // 'home', 'draw', 'away'
    public decimal Amount { get; set; }
    public decimal Odds { get; set; }
    public decimal Potential { get; set; }
    public string Status { get; set; } // 'pending', 'placed', 'won', 'lost'
    public DateTime Date { get; set; }
}