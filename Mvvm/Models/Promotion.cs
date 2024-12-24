namespace ECOllect.Models
{
    public class Promotion
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int PointsCost { get; set; }
        public DateTime ValidUntil { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}

