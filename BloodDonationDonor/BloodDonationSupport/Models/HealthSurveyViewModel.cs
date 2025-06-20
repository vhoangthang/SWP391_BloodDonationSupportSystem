using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSupport.Models
{
    public class HealthSurveyViewModel
    {
        public Dictionary<string, string> Answers { get; set; } = new();
    }
}
