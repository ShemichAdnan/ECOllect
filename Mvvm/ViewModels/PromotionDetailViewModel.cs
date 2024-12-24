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

    public string RelatedPromotionsTitle => $"Još od {Sponsor?.Name}";

    public ObservableCollection<Promotion> RelatedPromotions { get; } = new();

    private int _userPoints = 18;
    public int UserPoints
    {
        get => _userPoints;
        set => SetProperty(ref _userPoints, value);
    }

    public ICommand GoBackCommand { get; }
    public ICommand RedeemCommand { get; }
    public ICommand OpenPromotionCommand { get; }

    public PromotionDetailViewModel(Promotion promotion)
    {
        Promotion = promotion;
        Sponsor = promotion.Sponsor;
        LoadRelatedPromotions();

        GoBackCommand = new Command(async () => await GoBack());
        RedeemCommand = new Command(async () => await RedeemPromotion());
        OpenPromotionCommand = new Command<Promotion>(async (p) => await OpenPromotion(p));
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

    private async Task RedeemPromotion()
    {
        await Application.Current.MainPage.DisplayAlert("Success", "Nagrada je preuzeta!", "OK");
    }

    private async Task OpenPromotion(Promotion promotion)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new PromotionDetailPage(promotion));
    }
}

