namespace ECOllect.Models;

public class User
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; } = "profile_icon.png";
    public int Points { get; set; } = 0;
    public UserRole Role { get; set; } = UserRole.Korisnik;
}

public enum UserRole
{
    Korisnik,
    Organizator,
    Sponzor
}