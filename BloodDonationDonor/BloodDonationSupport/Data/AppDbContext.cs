using BloodDonationSupport.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSupport.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<DonationAppointment> DonationAppointments { get; set; }

        public DbSet<HealthSurvey> HealthSurveys { get; set; }

        public DbSet<MedicalCenter> MedicalCenters { get; set; }
    }
}
