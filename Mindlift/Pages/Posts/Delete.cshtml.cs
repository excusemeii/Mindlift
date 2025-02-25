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
    public class DeleteModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DeleteModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }

        public Forum Forum { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int forumId)
        {
            Forum = await _context.Forums.FindAsync(forumId);
            Post = await _context.Posts.FindAsync(id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Post == null)
            {
                return NotFound();
            }

            var postToDelete = await _context.Posts.FindAsync(Post.Id);

            if (postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { forumId = Post.ForumId });
        }
    }
}
