using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationAdmin.Models
{
    [Table("BloodRequest")]
    public class BloodRequest
    {
        [Key]
        public int BloodRequestId { get; set; }
        public int MedicalCenterId { get; set; }
        public int BloodTypeId { get; set; }

        public string? PatientName { get; set; }
        public string? Reason { get; set; }

        public DateTime RequestDate { get; set; }
        public int Quantity { get; set; }

        public bool IsEmergency { get; set; }
        public bool IsCompatible { get; set; }

        //public string? Status { get; set; } // Thêm cột này để lưu "Pending", "Approved", "Rejected"
    }
}
