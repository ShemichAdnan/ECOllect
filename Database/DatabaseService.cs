
using System;
using SQLite;
using System.IO;
using ECOllect.Models;
using ECOllect.Mvvm.Models;

namespace ECOllect.Database
{
    public static class DatabaseService
    {
        private static readonly string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EcollectforTesting.db3");

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(DatabasePath);
        }

        public static void InitializeDatabase()
        {
            using var connection = GetConnection();
            connection.CreateTable<User>(CreateFlags.None);
            connection.CreateTable<SignedAction>(CreateFlags.None);
            connection.CreateTable<CommunityAction>(CreateFlags.None);
        }
    }
}
