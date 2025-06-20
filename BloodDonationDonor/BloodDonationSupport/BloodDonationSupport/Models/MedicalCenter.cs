using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationSupport.Models
{
    [Table("MedicalCenter")]   
    
    public class MedicalCenter
    {
        [Key]
        public int MedicalCenterID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? ContactNumber { get; set; }

        public int BloodBankID { get; set; }
    }
}