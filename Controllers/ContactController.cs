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
                // Tạo một thực thể mới cho TbContact
                TbContact contact = new TbContact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System" // Hoặc gán giá trị phù hợp
                };

                // Thêm dữ liệu vào DbSet
                _context.TbContacts.Add(contact);

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                // Trả về trạng thái thành công
                return Json(new { status = true, message = "Dữ liệu đã được thêm vào thành công." });
            }
            catch (Exception ex)
            {
                // Trả về lỗi và thông tin
                return Json(new { status = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }

    }
}
