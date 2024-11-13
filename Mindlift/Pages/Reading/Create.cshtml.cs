using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Reading
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReadingProgress ReadingProgress { get; set; } = default!;

        public IActionResult OnGet()
        {
            ReadingProgress = new ReadingProgress
            {
                TotalBooksRead = 1,
                MilestoneLevel = "Bronze"
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure that milestone level and total books read are set correctly before saving
            if (ReadingProgress.Completed)
            {
                ReadingProgress.MarkAsCompleted(null);  // Pass User if needed for additional logic
            }

            // MilestoneLevel and TotalBooksRead are handled by backend and are not editable by the user

            _context.ReadingProgress.Add(ReadingProgress);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
