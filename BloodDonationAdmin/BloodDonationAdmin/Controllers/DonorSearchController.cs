using Microsoft.AspNetCore.Mvc;
using BloodDonationAdmin.Data;
using System.Linq;
using BloodDonationAdmin.Models;

namespace BloodDonationAdmin.Controllers
{
    public class DonorSearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorSearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(int bloodTypeId, string locationKeyword)
        {
            var donors = _context.Donors
    .Where(d => d.BloodTypeID == bloodTypeId
                && d.IsAvailable
                && d.Address != null
                && d.Address.Contains(locationKeyword))
    .ToList();


            return View(donors);
        }
    }
}
