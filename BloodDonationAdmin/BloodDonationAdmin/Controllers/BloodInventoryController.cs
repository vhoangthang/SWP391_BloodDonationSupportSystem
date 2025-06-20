using Microsoft.AspNetCore.Mvc;
using BloodDonationAdmin.Data;
using BloodDonationAdmin.Models;
using System.Linq;

namespace BloodDonationAdmin.Controllers
{
    public class BloodInventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodInventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inventories = _context.BloodInventories.ToList();
            return View(inventories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BloodInventory inventory)
        {
            inventory.LastUpdated = DateTime.Now;
            _context.BloodInventories.Add(inventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = _context.BloodInventories.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(BloodInventory inventory)
        {
            inventory.LastUpdated = DateTime.Now;
            _context.BloodInventories.Update(inventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.BloodInventories.Find(id);
            if (item != null)
            {
                _context.BloodInventories.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
