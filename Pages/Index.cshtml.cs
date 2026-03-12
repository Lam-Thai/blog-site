using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Pages;
using BlogSite.Models;
using BlogSite.Data;



public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }

    public List<Post> Posts { get; set; }
    public async Task OnGet()
    {
        Posts = await _context.Posts.Include(p => p.Author).Include(p => p.Category).ToListAsync();
    }
}
