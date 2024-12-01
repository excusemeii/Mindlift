using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.PostReplies
{
    public class DeleteModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DeleteModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PostReply Reply { get; set; } = default!;

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int postId)
        {
            Reply = await _context.PostReplies.FindAsync(id);
            if (Reply == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FindAsync(postId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Reply == null)
            {
                return NotFound();
            }

            var replyToDelete = await _context.PostReplies.FindAsync(Reply.Id);

            if (replyToDelete != null)
            {
                _context.PostReplies.Remove(replyToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { postId = Reply.PostId });
        }
    }
}
