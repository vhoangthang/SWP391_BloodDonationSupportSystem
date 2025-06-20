using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationAdmin.Models
{
    [Table("Donor")]
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }

        public int AccountID { get; set; }

        public int BloodTypeID { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? ContactNumber { get; set; }

        public string? Address { get; set; }

        public bool IsAvailable { get; set; }

        public string? CCCD { get; set; }
    }
}
