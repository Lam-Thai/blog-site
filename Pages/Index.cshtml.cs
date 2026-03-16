using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using BlogSite.Data;
using BlogSite.Models;

namespace BlogSite.Pages;

public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }

    public List<Post> Posts { get; set; }
    public List<Category> Categories { get; set; }

    public async Task OnGetAsync()
    {
        Posts = await _context.Posts
            .Include(p => p.Author)
            .Include(p => p.Category)
            .OrderByDescending(p => p.Id)
            .ToListAsync();

        Categories = await _context.Categories
            .Include(c => c.Posts)
            .Where(c => c.Posts.Any())
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}
