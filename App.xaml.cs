using ECOllect.Views;
using ECOllect.Models;
namespace ECOllect;

using System.Text.Json;

public partial class App : Application
{
    private static User _currentUser;
    public static User CurrentUser
    {
        get
        {
            if (_currentUser == null)
            {
                var userJson = Preferences.Get("CurrentUser", null);
                if (userJson != null)
                {
                    _currentUser = JsonSerializer.Deserialize<User>(userJson);
                }
            }
            return _currentUser;
        }
        set
        {
            _currentUser = value;
            if (value != null)
            {
                Preferences.Set("CurrentUser", JsonSerializer.Serialize(value));
            }
            else
            {
                Preferences.Remove("CurrentUser");
            }
        }
    }

    public App()
    {
        InitializeComponent();

        if (CurrentUser != null)
        {
            MainPage = new NavigationPage(new HomePage());
        }
        else
        {
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
