using ECOllect.Models;
using ECOllect.ViewModels;

namespace ECOllect.Views;

public partial class SponsorDetailPage : ContentPage
{
    public SponsorDetailPage(Sponsor sponsor)
    {
        InitializeComponent();
        BindingContext = new SponsorDetailViewModel(sponsor);
    }
}
