using ECOllect.Models;
using ECOllect.Mvvm.Models;

namespace ECOllect.Services;

public class MockDataService : IDataService 
{
    private static List<User> _users = new List<User>
    {
        new User
        {
            Email = "sapa@gmail.com",
            FirstName = "Ahmed",
            LastName = "Spahic",
            Address = "Krivace",
            PhoneNumber = "123456789",
            Points=30,
            ImageUrl="salcinovic.png",
            Role = UserRole.Korisnik
        },
        new User
        {
            Email = "sema@gmail.com",
            FirstName = "Adnan",
            LastName = "Semic",
            Address = "Plandiste 120",
            PhoneNumber = "123456789",
            ImageUrl="salcinovic.png",
            Role = UserRole.Organizator
        }
    };

    private static Dictionary<string, string> _passwords = new Dictionary<string, string>
    {
        { "sapa@gmail.com", "sapa123" },
        { "sema@gmail.com", "sema123" }
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