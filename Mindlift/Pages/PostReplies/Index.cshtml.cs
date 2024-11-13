using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;

namespace Mindlift.Pages.PostReplies
{
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PostReply> Replies { get; set; } = default!;
        public Post Post { get; set; }
        public int ForumId { get; set; }

        public async Task OnGetAsync(int postId)
        {
            Post = await _context.Posts.Include(p => p.Replies).FirstOrDefaultAsync(p => p.Id == postId);
            Replies = await _context.PostReplies.Where(r => r.PostId == postId).ToListAsync();
            ForumId = (int)Post.ForumId;
        }
    }
}
