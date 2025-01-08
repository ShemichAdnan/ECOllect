using System.Collections.ObjectModel;
using System.Windows.Input;
using ECOllect.Models;
using ECOllect.Views;

namespace ECOllect.ViewModels;

public class PromotionDetailViewModel : BaseViewModel
{
    private Promotion _promotion;
    public Promotion Promotion
    {
        get => _promotion;
        set => SetProperty(ref _promotion, value);
    }

    private Sponsor _sponsor;
    public Sponsor Sponsor
    {
        get => _sponsor;
        set => SetProperty(ref _sponsor, value);
    }

    public string RelatedPromotionsTitle => $"Jo� od {Sponsor?.Name}";

    public ObservableCollection<Promotion> RelatedPromotions { get; } = new();


    public ICommand GoBackCommand { get; }
    public ICommand RedeemCommand { get; }
    public ICommand OpenPromotionCommand { get; }
    public string UserImage => App.CurrentUser?.ImageUrl;
    public string Points => App.CurrentUser?.Points.ToString();
    public ICommand NavigateToProfileCommand { get; }
    public bool IsNotOrganizer => App.CurrentUser.Role.ToString() != "Organizator";
    public bool IsUser => App.CurrentUser?.Role == UserRole.Korisnik;
    public PromotionDetailViewModel(Promotion promotion)
    {
        Promotion = promotion;
        Sponsor = promotion.Sponsor;
        LoadRelatedPromotions();

        GoBackCommand = new Command(async () => await GoBack());
        RedeemCommand = new Command<Promotion>(async (p) => await RedeemPromotion(p));
        OpenPromotionCommand = new Command<Promotion>(async (p) => await OpenPromotion(p));
        NavigateToProfileCommand = new Command(async () => await NavigateToProfile());
    }

    private void LoadRelatedPromotions()
    {
        var related = Sponsor.Promotions
            .Where(p => p.Id != Promotion.Id)
            .ToList();

        foreach (var promotion in related)
        {
            RelatedPromotions.Add(promotion);
        }
    }

    private async Task GoBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    private async Task RedeemPromotion(Promotion promotion)
    {
        if (App.CurrentUser.Points < promotion.Points)
        {
            await Application.Current.MainPage.DisplayAlert("Greska", "Nemate dovoljno poena za preuzimanje nagrade!", "OK");
            return;
        }

        App.CurrentUser.Points -= promotion.Points;
        using var connection = DatabaseService.GetConnection();
        connection.Update(App.CurrentUser);

        await Application.Current.MainPage.DisplayAlert("Success", "Nagrada je preuzeta!", "OK");
    }

    private async Task OpenPromotion(Promotion promotion)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new PromotionDetailPage(promotion));
    }
    private async Task NavigateToProfile()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
    }
}

