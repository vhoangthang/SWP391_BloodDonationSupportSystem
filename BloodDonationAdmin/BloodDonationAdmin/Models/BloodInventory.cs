using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationAdmin.Models
{
    [Table("BloodInventory")]
    public class BloodInventory
    {
        [Key]
        public int InventoryID { get; set; }

        public int BloodTypeID { get; set; }

        public int BloodBankID { get; set; }

        public int Quantity { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
