using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
    public class Post
    {
        public int? Id { get; set; }

        [DisplayName("Title of the Forum")]
        [Required(ErrorMessage = "Forum Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        public int? ForumId { get; set; }
        public virtual Forum? Forum { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; } = new List<PostReply>();
    }
}
