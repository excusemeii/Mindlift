using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.PostReplies
{
    public class CreateModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public CreateModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PostId"] = new SelectList(_context.Set<Post>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PostReply Reply { get; set; } = default!;

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int postId)
        {
            Reply = new PostReply { PostId = postId }; // Set the post ID for the new reply
            Post = await _context.Posts.FindAsync(postId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Reply.Created = DateTime.Now;
            _context.PostReplies.Add(Reply);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { postId = Reply.PostId });
        }
    }
}
