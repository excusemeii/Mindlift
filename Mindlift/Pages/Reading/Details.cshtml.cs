using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;

namespace Mindlift.Pages.Reading
{
    public class DetailsModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DetailsModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ReadingProgress ReadingProgress { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readingprogress = await _context.ReadingProgress.FirstOrDefaultAsync(m => m.ReadingId == id);
            if (readingprogress == null)
            {
                return NotFound();
            }
            else
            {
                ReadingProgress = readingprogress;
            }
            return Page();
        }
    }
}
