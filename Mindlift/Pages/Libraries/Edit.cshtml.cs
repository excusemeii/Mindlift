using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Libraries
{
    public class EditModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public EditModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Library Library { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library =  await _context.Library.FirstOrDefaultAsync(m => m.LibraryID == id);
            if (library == null)
            {
                return NotFound();
            }
            Library = library;
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

            _context.Attach(Library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(Library.LibraryID))
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

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.LibraryID == id);
        }
    }
}
