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
        public DbSet<Mindlift.Models.Forum> Forum { get; set; } = default!;
        public DbSet<Mindlift.Models.User> User { get; set; } = default!;
        public DbSet<Mindlift.Models.Book> Book { get; set; } = default!;
        public DbSet<Mindlift.Models.VideoContent> VideoContent { get; set; } = default!;
        public DbSet<ReadingProgress> ReadingProgress { get; set; } = default!;
    }
}
