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
    public class DetailsModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DetailsModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Mindlift.Models.YouTubeVideo YouTubeVideo { get; set; } = default!; // Explicitly specify the namespace

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
                YouTubeVideo = youtubevideo; // Ensure this matches the expected type
            }
            return Page();
        }
    }
}
