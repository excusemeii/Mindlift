using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mindlift.Models
{
    public class VideoContent
    {
        public int VideoId { get; set; }
        public string? VideoTitle { get; set; }
        public string? Url { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Tags { get; set; }
    }
}
