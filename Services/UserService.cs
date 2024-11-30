// Services/UserService.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterUser(string username, string password)
    {
        var user = new User { Username = username, Password = password };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> LoginUser(string username, string password)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
    }

       public async Task<User> RechargeWallet(int userId, decimal amount)//Añadir saldo a la cartera
    {
        var user = await _context.Users.FindAsync(userId);//Buscar usuario por Id
        if (user != null)
        {
            user.Wallet += amount;//Añadir saldo
            await _context.SaveChangesAsync();
        }
        return user;
    }
}
