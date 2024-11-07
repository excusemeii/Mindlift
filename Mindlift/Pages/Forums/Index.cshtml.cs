using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.Forums
{
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Forum> Forum { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Forum = await _context.Forum.ToListAsync();
        }
    }
}
