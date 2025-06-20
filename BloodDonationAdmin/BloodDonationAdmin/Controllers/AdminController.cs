using Microsoft.AspNetCore.Mvc;
using BloodDonationAdmin.Data;
using BloodDonationAdmin.Models; // Nếu model User nằm đây
using System.Linq;

namespace BloodDonationAdmin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang: /Admin/ManageUsers
        public IActionResult ManageUsers()
        {
            var users = _context.Accounts.ToList(); // Lấy toàn bộ tài khoản từ DB
            return View(users); // Truyền danh sách qua View
        }


        

    }
}
