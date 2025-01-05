namespace ECOllect.Models;

public class CommunityAction
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int ParticipantCount { get; set; }
    public int Prize { get; set; }
    public string Image { get; set; }
    public bool HasJoined { get; set; }
}
