using Harmic1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic1.ViewComponents
{
    public class MenuTopViewComponent :ViewComponent 
    {
        private readonly DataTh2Context _context;

        public MenuTopViewComponent(DataTh2Context context)
        {
            _context = context;
     
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = _context.TbMenus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(item));
        }
    }
}
