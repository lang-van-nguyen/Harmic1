using Harmic1.Models;

using Microsoft.AspNetCore.Mvc;

namespace Harmic1.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataTh2Context _context;
        public ContactController(DataTh2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();

                return Json(new { status = true });

            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
