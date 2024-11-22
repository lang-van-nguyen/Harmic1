using Harmic1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic1.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly DataTh2Context _context;

        public ProductViewComponent(DataTh2Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbProducts.Include(m => m.CategoryProduct)
                .Where(m => (bool)m.IsActive).Where(m => m.IsNew);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
