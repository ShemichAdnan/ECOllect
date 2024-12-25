using System.Collections.ObjectModel;
using System.Windows.Input;
using ECOllect.Models;
using ECOllect.Views;

namespace ECOllect.ViewModels;

public class SponsorDetailViewModel : BaseViewModel
{
    

    private Sponsor _sponsor;
    public Sponsor Sponsor
    {
        get => _sponsor;
        set => SetProperty(ref _sponsor, value);
    }

    public string RelatedPromotionsTitle => $"{Sponsor?.Name} Vam nudi";

    public ObservableCollection<Promotion> RelatedPromotions { get; } = new();
    public ICommand GoBackCommand { get; }
    public ICommand OpenPromotionCommand { get; }

    public SponsorDetailViewModel(Sponsor sponsor)
    {
        Sponsor = sponsor;
        LoadRelatedPromotions();

        GoBackCommand = new Command(async () => await GoBack());
        OpenPromotionCommand = new Command<Promotion>(async (p) => await OpenPromotion(p));
    }
    private void LoadRelatedPromotions()
    {
        
        foreach (var promotion in Sponsor.Promotions)
        {
            RelatedPromotions.Add(promotion);
        }
    }

    private async Task GoBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    

    private async Task OpenPromotion(Promotion promotion)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new PromotionDetailPage(promotion));
    }
}
