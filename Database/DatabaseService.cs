
using System;
using SQLite;
using System.IO;

namespace ECOllect.Database
{
    public static class DatabaseService
    {
        private static readonly string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ECOllect.db3");

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(DatabasePath);
        }

        public static void InitializeDatabase()
        {
            using var connection = GetConnection();
            connection.CreateTable<User>(CreateFlags.None);
        }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; } = "profile_icon.png";
        public int Points { get; set; } = 0;
        public UserRole Role { get; set; } = UserRole.Korisnik;
    }
}
