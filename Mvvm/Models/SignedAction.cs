using SQLite;

namespace ECOllect.Models
{
    public class SignedAction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int UserId { get; set; }
    }
}
