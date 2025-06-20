using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationAdmin.Models
{
    [Table("Account")]
    public class Account
    {
        public int AccountID { get; set; }

        public int? MedicalCenterID { get; set; } // Cho phép null nếu không có MedicalCenter

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? Email { get; set; } // <-- Cho phép null

        public string? Role { get; set; }  // <-- Cho phép null

        public int? PermissionLevel { get; set; } // <-- Cho phép null
    }
}

