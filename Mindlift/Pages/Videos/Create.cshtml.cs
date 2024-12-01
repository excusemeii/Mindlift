using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Videos
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
            return Page();
        }

        [BindProperty]
        public Mindlift.Models.YouTubeVideo YouTubeVideo { get; set; } = default!; // Explicitly specify the namespace

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.YoutubeVideos.Add(YouTubeVideo); // Ensure consistency in type
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
