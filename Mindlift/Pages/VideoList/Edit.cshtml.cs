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

namespace Mindlift.Pages.VideoList
{
    public class EditModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public EditModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoContent VideoContent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videocontent =  await _context.VideoContent.FirstOrDefaultAsync(m => m.VideoId == id);
            if (videocontent == null)
            {
                return NotFound();
            }
            VideoContent = videocontent;
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

            _context.Attach(VideoContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoContentExists(VideoContent.VideoId))
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

        private bool VideoContentExists(int id)
        {
            return _context.VideoContent.Any(e => e.VideoId == id);
        }
    }
}
