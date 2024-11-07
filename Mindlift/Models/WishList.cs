using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Book")]
        [Required(ErrorMessage = "BookId is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Date Added is required")]
        [Display(Name = "Date Added to Wishlist")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } 
        
        public User User { get; set; }       
        public Book Book { get; set; }        
    }
}
