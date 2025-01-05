﻿using System.Windows.Input;
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

    private string _email;
    private string _phoneNumber;
    private string _address;
    
    public string NewEmail
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string NewPhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    public string NewAddress
    {
        get => _address;
        set => SetProperty(ref _address, value);
    }

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
        await Application.Current.MainPage.DisplayAlert("Report Error", "Prijavio si problem, kolege koje ovo upravo gledaju će ga riješiti :D.", "OK");
    }

    private async Task EditEmailAsync()
    {
        if (string.IsNullOrWhiteSpace(NewEmail))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Email ne može biti prazan.", "OK");
            return;
        }

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(NewEmail, emailPattern))
        {
            await Application.Current.MainPage.DisplayAlert("Greška", "Email nije validan", "OK");
            return;
        }

        using var connection = DatabaseService.GetConnection();
        var user = connection.Table<User>().FirstOrDefault(u => u.Id == App.CurrentUser.Id);

        if (user != null)
        {
            user.Email = NewEmail;
            connection.Update(user);
            await Application.Current.MainPage.DisplayAlert("Success", "Email uspješno ažuriran", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Korisnik nije pronadjen", "OK");
        }
    }

    private async Task EditPhoneAsync()
    {
        if (string.IsNullOrWhiteSpace(NewPhoneNumber))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Broj telefona ne smije biti prazan", "OK");
            return;
        }

        string phonePattern = @"^\+?[1-9]\d{1,14}$";
        if (!Regex.IsMatch(NewPhoneNumber, phonePattern))
        {
            await Application.Current.MainPage.DisplayAlert("Greška", "Broj telefona nije validan", "OK");
            return;
        }

        using var connection = DatabaseService.GetConnection();
        var user = connection.Table<User>().FirstOrDefault(u => u.Id == App.CurrentUser.Id);

        if (user != null)
        {
            user.PhoneNumber = NewPhoneNumber;
            connection.Update(user);
            await Application.Current.MainPage.DisplayAlert("Success", "Broj telefona uspjesno azuriran", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Korisnik nije pronadjen", "OK");
        }
    }

    private async Task EditAddressAsync()
    {
        if (string.IsNullOrWhiteSpace(Address))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Adresa ne moze biti prazna", "OK");
            return;
        }

        using var connection = DatabaseService.GetConnection();
        var user = connection.Table<User>().FirstOrDefault(u => u.Id == App.CurrentUser.Id);

        if (user != null)
        {
            user.Address = Address;
            connection.Update(user);
            await Application.Current.MainPage.DisplayAlert("Success", "Adresa uspjesno azurirana", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "User not found.", "OK");
        }
    }
}