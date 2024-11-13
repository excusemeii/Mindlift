using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindlift.Pages.Challenges
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Challenge> Challenge { get; set; } = default!;

        // Fetch the list of challenges on GET request
        public async Task OnGetAsync()
        {
            Challenge = await _context.Challenge.ToListAsync();
        }

        // Handle the progress update on POST request (via AJAX)
        public async Task<IActionResult> OnPostUpdateProgressAsync([FromBody] ProgressUpdateModel model)
        {
            var challenge = await _context.Challenge.FindAsync(model.Id);
            if (challenge == null)
            {
                return new JsonResult(new { success = false, message = "Challenge not found." });
            }

            challenge.BooksRead = model.BooksRead;

            await _context.SaveChangesAsync();

            // Return success response with updated BooksRead and Progress
            var progressPercentage = (challenge.TotalBooks > 0) ? (challenge.BooksRead * 100) / challenge.TotalBooks : 0;
            return new JsonResult(new { success = true, updatedBooksRead = challenge.BooksRead, progressPercentage });
        }
    }

    public class ProgressUpdateModel
    {
        public int Id { get; set; }
        public int BooksRead { get; set; }
    }
}
