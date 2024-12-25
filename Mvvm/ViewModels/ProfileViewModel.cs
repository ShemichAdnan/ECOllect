using System.Windows.Input;
using ECOllect.Models;
using ECOllect.Services;
using ECOllect.Views;
namespace ECOllect.ViewModels;

public class ProfileViewModel : BaseViewModel
{
    public string UserImage => App.CurrentUser?.ImageUrl;
    public string FullName => $"{App.CurrentUser?.FirstName} {App.CurrentUser?.LastName}";
    public string Email => App.CurrentUser?.Email;
    public string PhoneNumber => App.CurrentUser?.PhoneNumber;
    public string Address => App.CurrentUser?.Address;
    public string Points => App.CurrentUser?.Points.ToString();
    public string UserRole => App.CurrentUser?.Role.ToString();
    public bool IsNotOrganizer => App.CurrentUser.Role.ToString() != "Organizator";

    public ICommand LogoutCommand { get; }

    public ProfileViewModel()
    {
        LogoutCommand = new Command(async () => await LogoutAsync());
    }

    private async Task LogoutAsync()
    {
        bool answer = await Application.Current.MainPage.DisplayAlert(
            "Odjava",
            "Da li ste sigurni da se želite odjaviti?",
            "Da",
            "Ne");

        if (answer)
        {
            App.CurrentUser = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}