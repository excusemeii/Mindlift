namespace Mindlift.Models
{
    public class Challenge
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Theme { get; set; }  
        public string BookTitle { get; set; }  
        public string BookCoverUrl { get; set; }
        public int BooksRead { get; set; }
        public int TotalBooks { get; set; }

    }
}
