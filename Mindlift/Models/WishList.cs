using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Date Added is required")] 
        public DateTime DateAdded { get; set; } 

        
        public User User { get; set; }       
        public Book Book { get; set; }        
    }
}
