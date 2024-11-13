using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;

namespace Mindlift.Pages.Reading
{
    public class EditModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public EditModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReadingProgress ReadingProgress { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readingprogress =  await _context.ReadingProgress.FirstOrDefaultAsync(m => m.ReadingId == id);
            if (readingprogress == null)
            {
                return NotFound();
            }
            ReadingProgress = readingprogress;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReadingProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingProgressExists(ReadingProgress.ReadingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReadingProgressExists(int id)
        {
            return _context.ReadingProgress.Any(e => e.ReadingId == id);
        }
    }
}
