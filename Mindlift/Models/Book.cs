using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mindlift.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double RatingsAvg { get; set; }
        public int RatingsCount { get; set; }
        public DateTime PublishedDate { get; set; }

        // many-to-many relationship with Review table
        public List<Review>? Reviews { get; set; }
    }
}