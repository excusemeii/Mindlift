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
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ReadingProgress> ReadingProgress { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ReadingProgress = await _context.ReadingProgress.ToListAsync();
        }
    }
}
