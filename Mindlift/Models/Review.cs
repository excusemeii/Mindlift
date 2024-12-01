using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mindlift.Models
{
    public class Review
    {

        [DisplayName("Title of the Book")]
        [Required(ErrorMessage = "Book Title is required")]
        public string BookTitle { get; set; }
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(500, ErrorMessage = "Comment cannot be more than 500 characters")]
        public string Comment { get; set; }

        [DisplayName("Review Date")]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        // many-to-many relationship with Book table
        public List<Book>? Book { get; set; }
    }
}
