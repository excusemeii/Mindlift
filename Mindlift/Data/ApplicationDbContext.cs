using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mindlift.Models;

namespace Mindlift.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mindlift.Models.Review> Review { get; set; } = default!;
        public DbSet<Mindlift.Models.Library> Library { get; set; } = default!;

        public DbSet<Mindlift.Models.YouTubeVideo> YoutubeVideos { get; set; } = default!;

        //public DbSet<Mindlift.Models.YouTubeApiService> YouTubeApiService { get; set; } = default!;
    }
}
