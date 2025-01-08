using System.Windows.Input;
using ECOllect.Database;
using ECOllect.Models;
using ECOllect.Views;

namespace ECOllect.ViewModels;

public class ActionDetailViewModel : BaseViewModel
{
    private readonly CommunityAction _action;

    public int Id => _action.Id;
    public string Title => _action.Title;
    public string Description => _action.Description;
    public DateTime Date => _action.Date;
    public string Location => _action.Location;
    public double Latitude => _action.Latitude;
    public double Longitude => _action.Longitude;
    public int Prize => _action.Prize;
    public int ParticipantCount => _action.Participants;
    public string Image => _action.Image;
    public string UserImage => App.CurrentUser?.ImageUrl;
    public string Points => App.CurrentUser?.Points.ToString();
    public bool IsNotOrganizer => App.CurrentUser.Role.ToString() != "Organizator";
    public bool isParticipant => DatabaseService.GetConnection().Table<SignedAction>().FirstOrDefault(u => u.ActionId == Id && u.UserId == App.CurrentUser.Id) != null;
    public bool isNotParticipant => DatabaseService.GetConnection().Table<SignedAction>().FirstOrDefault(u => u.ActionId == Id && u.UserId == App.CurrentUser.Id) == null;
    public ICommand NavigateToProfileCommand { get; }
    public ICommand SignActionCommand { get; }
    public ICommand UnsignActionCommand { get; }

    public ActionDetailViewModel(CommunityAction action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
        NavigateToProfileCommand = new Command(async () => await NavigateToProfile());
        SignActionCommand = new Command(async () => await SignActionAsync());
        UnsignActionCommand = new Command(async () => await UnsignActionAsync());

    }

    private async Task SignActionAsync()
    {
        using var connection = DatabaseService.GetConnection();
        var action = connection.Table<SignedAction>().FirstOrDefault(u => u.ActionId == Id && u.UserId == App.CurrentUser.Id);

        if (action != null)
        {
            await Application.Current.MainPage.DisplayAlert("Greška", "Već ste se prijavili na ovu akciju", "OK");
            return;
        }

        var signedAction = new SignedAction
        {
            ActionId = Id,
            UserId = App.CurrentUser.Id
        };

        connection.Insert(signedAction);
        await Application.Current.MainPage.DisplayAlert("Uspješno", "Uspješno ste se prijavili na akciju", "OK");
    }

    private async Task UnsignActionAsync()
    {
        using var connection = DatabaseService.GetConnection();
        var action = connection.Table<SignedAction>().FirstOrDefault(u => u.ActionId == Id && u.UserId == App.CurrentUser.Id);

        if (action == null)
        {
            await Application.Current.MainPage.DisplayAlert("Greška", "Niste se prijavili na ovu akciju", "OK");
            return;
        }

        connection.Delete(action);
        await Application.Current.MainPage.DisplayAlert("Uspješno", "Odjavili ste se sa akcije", "OK");
    }

    private async Task NavigateToProfile()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
    }
}