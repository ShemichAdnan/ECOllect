using System.Collections.ObjectModel;
using ECOllect.Models;

namespace ECOllect.Services;

public class DataService : IDataService
{
    public ObservableCollection<CommunityAction> GetActions() => SampleData.GetSampleActions();
    public ObservableCollection<Sponsor> GetSponsors() => SampleData.GetSampleSponsors();
}
