using BloodDonationSupport.Data;
using BloodDonationSupport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BloodDonationSupport.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy username từ session
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Index", "Login");

            // Tìm account theo username
            var account = _context.Accounts.FirstOrDefault(a => a.Username == username);
            if (account == null)
                return NotFound();

            // Tìm donor theo AccountID
            var donor = _context.Donor
                .Include(d  => d.BloodType)
                .FirstOrDefault(d => d.AccountID == account.AccountID);
            if (donor == null)
                return NotFound();

            // Truyền email từ account vào ViewBag
            ViewBag.Email = account.Email;
            return View(donor);
        }

        public IActionResult Edit()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Index", "Login");

            var account = _context.Accounts.FirstOrDefault(a => a.Username == username);
            if (account == null)
                return NotFound();

            var donor = _context.Donor.FirstOrDefault(d => d.AccountID == account.AccountID);
            if (donor == null)
                return NotFound();
            ViewBag.BloodTypes = new SelectList(_context.BloodTypes.ToList(), "BloodTypeID", "Type", donor.BloodTypeID);
            return View(donor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BloodTypes = new SelectList(_context.BloodTypes.ToList(), "BloodTypeID", "Type", donor.BloodTypeID);
                return View(donor);
            }
                

            var existingDonor = _context.Donor.FirstOrDefault(d => d.DonorID == donor.DonorID);
            if (existingDonor == null)
                return NotFound();

            // Cập nhật thông tin
            existingDonor.Name = donor.Name;
            existingDonor.DateOfBirth = donor.DateOfBirth;
            existingDonor.Gender = donor.Gender;
            existingDonor.ContactNumber = donor.ContactNumber;
            existingDonor.Address = donor.Address;
            existingDonor.IsAvailable = donor.IsAvailable;
            existingDonor.CCCD = donor.CCCD;
            existingDonor.BloodTypeID = donor.BloodTypeID;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 