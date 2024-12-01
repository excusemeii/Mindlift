using Microsoft.Extensions.Hosting;

namespace Mindlift.Models
{
        // Forum class representing the main forum system
    public class Forum
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
    }
          
}
