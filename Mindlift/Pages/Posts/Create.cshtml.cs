using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public CreateModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        public Forum Forum { get; set; }
        public async Task<IActionResult> OnGetAsync(int forumId)
        {
            Forum = await _context.Forums.FindAsync(forumId);
            Post = new Post { ForumId = forumId }; // Set the forum ID for the new post
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post.Created = DateTime.Now;
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { forumId = Post.ForumId });
        }
    }
}
