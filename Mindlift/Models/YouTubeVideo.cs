using System.ComponentModel.DataAnnotations;

namespace Mindlift.Models
{
    public class YouTubeVideo
    {
        [Key]
        public string VideoId { get; set; }  // Primary key

        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ChannelTitle { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
    }
}
