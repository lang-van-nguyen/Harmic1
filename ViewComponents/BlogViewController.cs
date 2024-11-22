using Harmic1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic1.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly DataTh2Context _context;

        public BlogViewComponent(DataTh2Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs
                .Where(b => (bool)b.IsActive == true)
                .OrderByDescending(b => b.BlogId);

            return await Task.FromResult<IViewComponentResult>
                (View(items.ToList())
            );
        }
    }
}