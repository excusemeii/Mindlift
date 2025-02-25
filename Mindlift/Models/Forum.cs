using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
        // Forum class representing the main forum system
    public class Forum
    {
        public int? Id { get; set; }

        [DisplayName("Title of the Forum")]
        [Required(ErrorMessage = "Forum Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
    }
          
}
