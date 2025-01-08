using System.Collections.ObjectModel;
using ECOllect.Models;
using System.Windows.Input;
using ECOllect.Views;
using System.Linq;
using ECOllect.Database;

namespace ECOllect.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public ObservableCollection<CommunityAction> DisplayedActions { get; } = new();
    public ObservableCollection<Sponsor> Sponsors { get; } = new();
    public ICommand NavigateToSponsorDetailCommand { get; }

    private readonly ObservableCollection<CommunityAction> _allActions;
    private int _currentIndex = 0;
    private const int ItemsPerLoad = 3;

    public ICommand LoadMoreCommand { get; }
    public ICommand NavigateToDetailCommand { get; }
    public ICommand NavigateToPromotionCommand { get; }
    public ICommand NavigateToNewActionPage { get; }

    private bool _isLoadMoreButtonVisible = true;
    public bool IsLoadMoreButtonVisible
    {
        get => _isLoadMoreButtonVisible;
        set => SetProperty(ref _isLoadMoreButtonVisible, value);
    }

    private ObservableCollection<Sponsor> _allSponsors;
    private ObservableCollection<Sponsor> _displayedSponsors;
    public ObservableCollection<Sponsor> DisplayedSponsors
    {
        get => _displayedSponsors;
        set => SetProperty(ref _displayedSponsors, value);
    }

    private int _sponsorsCurrentIndex = 0;
    private const int SponsorsPerLoad = 2;

    public ICommand LoadMoreSponsorsCommand { get; }
    public ICommand RemoveActionCommand { get; }
    private bool _isLoadMoreSponsorsVisible = true;
    public bool IsLoadMoreSponsorsVisible
    {
        get => _isLoadMoreSponsorsVisible;
        set => SetProperty(ref _isLoadMoreSponsorsVisible, value);
    }
    public ICommand NavigateToProfileCommand { get; }

    public HomeViewModel()
    {
        _allActions = SampleData.GetSampleActions();
        Sponsors = SampleData.GetSampleSponsors();

        LoadInitialItems();
        LoadMoreCommand = new Command(LoadMoreItems);
        NavigateToDetailCommand = new Command<CommunityAction>(async (action) =>
        {
            if (action != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ActionDetailPage(action));
            }
        });

        NavigateToPromotionCommand = new Command<Promotion>(async (promotion) =>
        {
            if (promotion != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PromotionDetailPage(promotion));
            }
            
        });

        NavigateToNewActionPage = new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewActionPage());
        });

        NavigateToSponsorDetailCommand = new Command<Sponsor>(async (sponsor) =>
        {
            if (sponsor != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new SponsorDetailPage(sponsor));
            }
        });
        
        RemoveActionCommand = new Command<CommunityAction>(async (p) => await RemoveAction(p));



        _allSponsors = SampleData.GetSampleSponsors();
        DisplayedSponsors = new ObservableCollection<Sponsor>();
        LoadMoreSponsorsCommand = new Command(LoadMoreSponsors);
        LoadInitialSponsors();
        NavigateToProfileCommand = new Command(async () => await NavigateToProfile());

    }
    
    private async Task RemoveAction(CommunityAction action)
    {
        if (action != null)
        {
            if (await Application.Current.MainPage.DisplayAlert("Warning", "Jeste li sigurni da želite izbrisati ovu akciju?", "Da", "Ne"))
            {
                using var connection = DatabaseService.GetConnection();
                connection.Delete(action);
                _allActions.Remove(action);
                DisplayedActions.Remove(action);
            }
        }
    }

    private void LoadInitialItems() => LoadMoreItems();

    private void LoadMoreItems()
    {
        var itemsToAdd = _allActions.Skip(_currentIndex).Take(ItemsPerLoad).ToList();
        foreach (var item in itemsToAdd)
        {
            DisplayedActions.Add(item);
        }
        _currentIndex += ItemsPerLoad;

        IsLoadMoreButtonVisible = _currentIndex < _allActions.Count;
    }

    private void LoadInitialSponsors()
    {
        LoadMoreSponsors();
    }

    private void LoadMoreSponsors()
    {
        var sponsorsToAdd = _allSponsors
            .Skip(_sponsorsCurrentIndex)
            .Take(SponsorsPerLoad)
            .ToList();

        foreach (var sponsor in sponsorsToAdd)
        {
            DisplayedSponsors.Add(sponsor);
        }

        _sponsorsCurrentIndex += SponsorsPerLoad;
        IsLoadMoreSponsorsVisible = _sponsorsCurrentIndex < _allSponsors.Count;
    }
    public string Points => App.CurrentUser?.Points.ToString() ?? "0";
    public string UserImage => App.CurrentUser?.ImageUrl ?? "profile_icon.png";
    public bool IsNotOrganizer => App.CurrentUser?.Role != UserRole.Organizator;

    public bool IsOrganizer => App.CurrentUser?.Role == UserRole.Organizator;
    public bool IsUser => App.CurrentUser?.Role == UserRole.Korisnik;
    public bool IsSponsor => App.CurrentUser?.Role == UserRole.Sponzor;

    private async Task NavigateToProfile()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
    }
}

