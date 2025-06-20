using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSupport.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
