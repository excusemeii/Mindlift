using Microsoft.Extensions.Hosting;

namespace Mindlift.Models
{
    public class Forum
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
    }
}
