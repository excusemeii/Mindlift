using Humanizer.Localisation;
using System.Threading;

namespace Mindlift.Models
{
        // Forum class representing the main forum system
        public class Forum
        {
            public int Id { get; set; }
            public string? ForumName { get; set; }
            public List<User>? Users { get; set; } 

        }
          
}
