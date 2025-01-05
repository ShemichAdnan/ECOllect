using System.Collections.ObjectModel;
using ECOllect.Models;
using ECOllect.Mvvm.Models;

namespace ECOllect.Services;

public interface IDataService
{
    
    Task<User> LoginUser(string email, string password);
    Task<bool> RegisterUser(User user, string password);
}
