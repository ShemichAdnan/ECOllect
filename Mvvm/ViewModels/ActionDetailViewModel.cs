using ECOllect.Models;

namespace ECOllect.ViewModels;

public class ActionDetailViewModel : BaseViewModel
{
    private readonly CommunityAction _action;

    public string Id => _action.Id;
    public string Title => _action.Title;
    public string Description => _action.Description;
    public DateTime Date => _action.Date;
    public string Location => _action.Location;
    public double Latitude => _action.Latitude;
    public double Longitude => _action.Longitude;
    public int ParticipantCount => _action.ParticipantCount;
    public int Prize => _action.Prize;
    public string Image => _action.Image;
    public bool HasJoined => _action.HasJoined;

    public ActionDetailViewModel(CommunityAction action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
    }
}