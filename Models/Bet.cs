// Models/Bet.cs
public class Bet
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PartidoId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
