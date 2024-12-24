using System.Collections.ObjectModel;
using ECOllect.Models;

namespace ECOllect.Services;

public interface IDataService
{
    ObservableCollection<CommunityAction> GetActions();
    ObservableCollection<Sponsor> GetSponsors();
}
