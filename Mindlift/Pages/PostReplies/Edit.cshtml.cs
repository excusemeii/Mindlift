using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.PostReplies
{
    public class EditModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public EditModel(Mindlift.Data.ApplicationDbContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostReplyExists((int)Reply.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { postId = Reply.PostId });
        }

        private bool PostReplyExists(int id)
        {
            return _context.PostReplies.Any(e => e.Id == id);
        }
    }
}
