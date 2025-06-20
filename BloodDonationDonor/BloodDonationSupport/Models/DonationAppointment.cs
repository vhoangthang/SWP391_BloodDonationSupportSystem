using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonationSupport.Models
{
    [Table("DonationAppointment")]
    public class DonationAppointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int DonorID { get; set; }
        public int MedicalCenterID { get; set; }
        public int BloodTypeID { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } // "Sáng" hoặc "Chiều"
        public string Status { get; set; }
        public string HealthSurvey { get; set; } // JSON
        public BloodType BloodType { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}