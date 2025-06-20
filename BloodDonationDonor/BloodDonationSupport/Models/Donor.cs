using System.ComponentModel.DataAnnotations;

namespace BloodDonationSupport.Models
{
    public class Donor
    {
        public int DonorID { get; set; }
        public int AccountID { get; set; }
        public int BloodTypeID { get; set; }

        // not null variable (REQUIRE)
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public bool? IsAvailable { get; set; }
        public string? CCCD { get; set; }
        public string? Gender { get; set; }

        // Navigation property
        public Account? Account { get; set; }
        public BloodType? BloodType { get; set; }
    }
} 