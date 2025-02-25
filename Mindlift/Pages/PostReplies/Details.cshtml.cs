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
    public class DetailsModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DetailsModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PostReply PostReply { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postreply = await _context.PostReplies.FirstOrDefaultAsync(m => m.Id == id);
            if (postreply == null)
            {
                return NotFound();
            }
            else
            {
                PostReply = postreply;
            }
            return Page();
        }
    }
}
