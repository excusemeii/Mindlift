using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.WishLists
{
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Wishlist> Wishlist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Wishlist = await _context.Wishlist
                .Include(w => w.Book)
                .Include(w => w.User).ToListAsync();
        }
    }
}
