using System;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationSupport.Models
{
    public class BookAppointmentViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }

        [Required]
        public string TimeSlot { get; set; } // "Sáng" hoặc "Chiều"

        [Required]
        public int BloodTypeID { get; set; }
    }
}