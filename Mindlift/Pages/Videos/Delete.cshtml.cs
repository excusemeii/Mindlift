using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Videos
{
    public class DeleteModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DeleteModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mindlift.Models.YouTubeVideo YouTubeVideo { get; set; } = default!; // Ensure proper namespace

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youtubevideo = await _context.YoutubeVideos.FirstOrDefaultAsync(m => m.VideoId == id);

            if (youtubevideo == null)
            {
                return NotFound();
            }
            else
            {
                YouTubeVideo = youtubevideo; // Ensure compatibility in type
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youtubevideo = await _context.YoutubeVideos.FindAsync(id);
            if (youtubevideo != null)
            {
                YouTubeVideo = youtubevideo; // Ensure compatibility in type
                _context.YoutubeVideos.Remove(youtubevideo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}