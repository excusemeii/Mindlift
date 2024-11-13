using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.VideoList
{
    public class DetailsModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DetailsModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public VideoContent VideoContent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videocontent = await _context.VideoContent.FirstOrDefaultAsync(m => m.VideoId == id);
            if (videocontent == null)
            {
                return NotFound();
            }
            else
            {
                VideoContent = videocontent;
            }
            return Page();
        }
    }
}
