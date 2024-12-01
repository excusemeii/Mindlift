using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Libraries
{
    public class DetailsModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public DetailsModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Library Library { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FirstOrDefaultAsync(m => m.LibraryID == id);
            if (library == null)
            {
                return NotFound();
            }
            else
            {
                Library = library;
            }
            return Page();
        }
    }
}
