// Models/Bet.cs
public class Bet
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MatchId { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public decimal Odds { get; set; }
    public decimal Potential { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public bool IsValidated { get; set; } 
}