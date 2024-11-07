namespace Mindlift.Models
{
    // User class representing a forum user
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime? JoinDate { get; set; }

    }
}
