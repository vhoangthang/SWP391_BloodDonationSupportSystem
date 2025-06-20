using System.Collections.Generic;

namespace BloodDonationSupport.Models
{
    public class DonationSummaryViewModel
    {
        public DonationAppointment Appointment { get; set; }
        public Donor Donor { get; set; }
        public Dictionary<string, string> HealthSurveyAnswers { get; set; }
    }
}