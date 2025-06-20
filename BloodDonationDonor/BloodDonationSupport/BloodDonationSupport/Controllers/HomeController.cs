using System.Diagnostics;
using BloodDonationSupport.Models;
using Microsoft.AspNetCore.Mvc;
using BloodDonationSupport.Data;

namespace BloodDonationSupport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            ViewBag.IsLoggedIn = !string.IsNullOrEmpty(username);
            ViewBag.Username = username;

            int? latestAppointmentId = null;
            if (!string.IsNullOrEmpty(username))
            {
                var account = _context.Accounts.FirstOrDefault(a => a.Username == username);
                if (account != null)
                {
                    var donor = _context.Donor.FirstOrDefault(d => d.AccountID == account.AccountID);
                    if (donor != null)
                    {
                        var latestAppointment = _context.DonationAppointments
                            .Where(a => a.DonorID == donor.DonorID)
                            .OrderByDescending(a => a.AppointmentDate)
                            .FirstOrDefault();
                        if (latestAppointment != null)
                        {
                            latestAppointmentId = latestAppointment.AppointmentID;
                        }
                    }
                }
            }
            ViewBag.LatestAppointmentId = latestAppointmentId;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
