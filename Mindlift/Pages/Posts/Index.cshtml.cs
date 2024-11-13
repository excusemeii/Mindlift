using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Posts { get; set; } = default!;
        public Forum Forum { get; set; }

        public async Task OnGetAsync(int forumId)
        {
            Forum = await _context.Forums.FindAsync(forumId);
            Posts = await _context.Posts.Where(p => p.ForumId == forumId).ToListAsync();
        }
    }
}