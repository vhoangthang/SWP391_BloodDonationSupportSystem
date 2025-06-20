using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationSupport.Models
{
    [Table("Account")]
    public class Account
    {
        public int AccountID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
