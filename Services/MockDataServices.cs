using ECOllect.Models;
using ECOllect.Mvvm.Models;

namespace ECOllect.Services;

public class MockDataService : IDataService 
{
    private static List<User> _users = new List<User>
    {
        new User
        {
            Email = "sapaaaaaaaaaaa@gmail.com",
            FirstName = "Ahmed",
            LastName = "Spahic",
            Address = "Krivace",
            PhoneNumber = "123456789",
            Points=30,
            Role = UserRole.Korisnik
        },
        new User
        {
            Email = "semaaaaaaaaaaaaa@gmail.com",
            FirstName = "Adnan",
            LastName = "Semic",
            Address = "Plandiste 120",
            PhoneNumber = "123456789",
            Role = UserRole.Organizator
        }
    };

    private static Dictionary<string, string> _passwords = new Dictionary<string, string>
    {
        { "sapaaaaaaaaaaa@gmail.com", "sapa123" },
        { "semaaaaaaaaaaaaa@gmail.com", "sema123" }
    };

    

    public async Task<User> LoginUser(string email, string password)
    {
        
        if (_passwords.TryGetValue(email, out string storedPassword) && storedPassword == password)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
        return null;
    }

    public async Task<bool> RegisterUser(User user, string password)
    {
        
        if (_users.Any(u => u.Email == user.Email))
        {
            return false;
        }

        _users.Add(user);
        _passwords[user.Email] = password;
        return true;
    }
}