using ECOllect.ViewModels;
using ECOllect.Models;

namespace ECOllect.Views;

public partial class PromotionDetailPage : ContentPage
{
    public PromotionDetailPage(Promotion promotion)
    {
        InitializeComponent();
        BindingContext = new PromotionDetailViewModel(promotion);
    }
}

