using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUser(string username, string password)
    {
        // Проверяем, существует ли уже пользователь с этим именем
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if(user != null)
        {
            // Если пользователь существует, возвращаем false
            return false;
        }
        
        user = new User
        {
            Username = username,
            Password = password // в реальной ситуации вы бы хешировали пароль
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> AuthenticateUser(string username, string password)
    {
        // Ищем пользователя по имени и проверяем пароль
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if(user == null)
        {
            // Если пользователь не найден, возвращаем false
            return false;
        }

        // В реальной ситуации вы бы сравнивали хеши паролей
        return user.Password == password;
    }
}