// Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Wallet { get; set; } = 0; // Asignar 0 por defecto
}
