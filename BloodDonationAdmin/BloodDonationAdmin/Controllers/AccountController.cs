using Microsoft.AspNetCore.Mvc;
using BloodDonationAdmin.Data;
using System.Linq;

using BloodDonationAdmin.Models;

namespace BloodDonationAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context) => _context = context;

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null && (user.Role == "Admin" || user.Role == "MedicalCenter"))
            {
                HttpContext.Session.SetString("username", user.Username);
                HttpContext.Session.SetString("role", user.Role);

                // ✅ Chuyển trang sau khi login
                return RedirectToAction("ManageUsers", "Admin");
            }

            ViewBag.Message = "Sai tài khoản hoặc mật khẩu hoặc không có quyền truy cập.";
            return View();
        }
        public IActionResult Logout()
        {
            // Xóa session
            HttpContext.Session.Clear();

            // Điều hướng về trang đăng nhập
            return RedirectToAction("Login", "Account");
        }

    }
    }

