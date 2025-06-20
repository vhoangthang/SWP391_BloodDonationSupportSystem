using Microsoft.EntityFrameworkCore;
using BloodDonationAdmin.Models;

namespace BloodDonationAdmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<BloodRequest> BloodRequests { get; set; }

        public DbSet<BloodInventory> BloodInventories { get; set; }

        public DbSet<Donor> Donors { get; set; }



    }
}
