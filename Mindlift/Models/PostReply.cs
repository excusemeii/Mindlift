using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
    public class PostReply
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        public int? PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
