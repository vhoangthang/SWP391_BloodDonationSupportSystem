using Microsoft.AspNetCore.Mvc;
using BloodDonationSupport.Data;
using BloodDonationSupport.Models;
using System.Linq;

namespace BloodDonationSupport.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("Username"));
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Index", "Home");
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var acc = _context.Accounts.FirstOrDefault(a =>
                    a.Username == model.Username &&
                    a.Password == model.Password &&
                    a.Role == model.Role);

                if (acc != null)
                {
                    HttpContext.Session.SetString("Username", acc.Username);
                    HttpContext.Session.SetString("Role", acc.Role); // nếu muốn

                    switch (acc.Role.ToLower())
                        {
                            case "donor":
                                return RedirectToAction("Index", "Home");
                            case "staff":
                                // TODO: Xử lý sau
                                break;
                            case "admin":
                                // TODO: Xử lý sau
                                break;
                        }
                }

                ModelState.AddModelError("", "Sai thông tin đăng nhập.");
            }

            return View(model);
        }
    }
}
