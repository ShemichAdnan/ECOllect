namespace ECOllect.Models
{
    public class Sponsor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Advertisement { get; set; }
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}