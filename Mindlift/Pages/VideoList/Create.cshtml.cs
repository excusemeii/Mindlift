﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.VideoList
{
    public class CreateModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public CreateModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VideoContent VideoContent { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VideoContent.Add(VideoContent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
