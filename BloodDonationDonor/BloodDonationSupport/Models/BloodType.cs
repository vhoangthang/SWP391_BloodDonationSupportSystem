using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationSupport.Models
{
    [Table("BloodType")]
    public class BloodType
    {
        public int BloodTypeID { get; set; }
        public string Type { get; set; }
    }
}
