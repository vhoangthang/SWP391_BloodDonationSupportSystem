using Microsoft.AspNetCore.Mvc;
using BloodDonationAdmin.Data;
using BloodDonationAdmin.Models;
using System.Linq;

namespace BloodDonationAdmin.Controllers
{
    public class BloodRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var requests = _context.BloodRequests.ToList();
            return View(requests);
        }

        public IActionResult Approve(int id)
        {
            var request = _context.BloodRequests.Find(id);
            if (request != null)
            {
                // Nếu cần xử lý gì khi duyệt, bạn xử lý ở đây
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            var request = _context.BloodRequests.Find(id);
            if (request != null)
            {
                // Nếu cần xử lý gì khi từ chối, bạn xử lý ở đây
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
