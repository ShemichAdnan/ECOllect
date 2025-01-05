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
    public ICommand GoBackCommand { get; }
    public ICommand ReportErrorCommand { get; }
    public ICommand EditEmailCommand { get; }
    public ICommand EditPhoneCommand { get; }
    public ICommand EditAddressCommand { get; }
    public bool IsOrganizer => App.CurrentUser?.Role.ToString() == "Organizator";
    public bool IsUser => App.CurrentUser?.Role.ToString() == "Korisnik";
    public bool IsSponsor => App.CurrentUser?.Role.ToString() == "Sponzor";

    public ProfileViewModel()
    {
        LogoutCommand = new Command(async () => await LogoutAsync());
        GoBackCommand = new Command(async () => await GoBackAsync());
        ReportErrorCommand = new Command(async () => await ReportErrorAsync());
        EditEmailCommand = new Command(async () => await EditEmailAsync());
        EditPhoneCommand = new Command(async () => await EditPhoneAsync());
        EditAddressCommand = new Command(async () => await EditAddressAsync());
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
    private async Task GoBackAsync()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    private async Task ReportErrorAsync()
    {
        await Application.Current.MainPage.DisplayAlert(
            "Prijava greške",
            "Ova funkcionalnost će biti dostupna uskoro.",
            "OK");
    }

    private async Task EditEmailAsync()
    {
        // Implement email editing functionality
        await Application.Current.MainPage.DisplayAlert(
            "Uredi email",
            "Ova funkcionalnost će biti dostupna uskoro.",
            "OK");
    }

    private async Task EditPhoneAsync()
    {
        // Implement phone editing functionality
        await Application.Current.MainPage.DisplayAlert(
            "Uredi telefon",
            "Ova funkcionalnost će biti dostupna uskoro.",
            "OK");
    }

    private async Task EditAddressAsync()
    {
        // Implement address editing functionality
        await Application.Current.MainPage.DisplayAlert(
            "Uredi adresu",
            "Ova funkcionalnost će biti dostupna uskoro.",
            "OK");
    }
}