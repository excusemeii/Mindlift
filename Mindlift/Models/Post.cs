namespace Mindlift.Models
{
    public class Post
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Created { get; set; }
        public int? ForumId { get; set; }
        public virtual Forum? Forum { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; } = new List<PostReply>();
    }
}
