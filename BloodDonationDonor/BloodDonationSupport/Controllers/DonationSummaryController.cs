using BloodDonationSupport.Data;
using BloodDonationSupport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;

namespace BloodDonationSupport.Controllers
{
    public class DonationSummaryController : Controller
    {
        private readonly AppDbContext _context;
        private static readonly Dictionary<string, string> HealthSurveyQuestions = new()
        {
            { "1_AnhChiDaTungHienMauChua", "1. Anh/Chị từng hiến máu chưa?" },
            { "2_HienTaiAnhChiCoMacBenhLyKhong", "2. Hiện tại, anh/chị có mắc bệnh lý nào không?" },
            { "3_TruocDayAnhChiCoMacCacBenhLietKeKhong", "3. Trước đây, anh/chị có từng mắc một trong các bệnh: viêm gan siêu vi B, C, HIV, ..." },
            { "4_KhoiBenhSauMacCacBenh12Thang", "4.1 Anh/Chị có khỏi bệnh sau sốt rét, giang mai, lao, phẫu thuật không?" },
            { "4_DuocTruyenMauHoacGayGhepMo", "4.2 Anh/Chị có được truyền máu hoặc ghép mô không?" },
            { "4_TiemVaccine", "4.3 Gần đây anh/chị có tiêm vaccine không?" },
            { "5_KhoiBenhSauMacCacBenh6Thang", "5. Trong 06 tháng gần đây, anh/chị có khỏi bệnh sau các bệnh truyền nhiễm, viêm tủy không?" },
            { "6_KhoiBenhSauMacCacBenh1Thang", "6. Trong 01 tháng gần đây, anh/chị có khỏi bệnh viêm tiết niệu, viêm phổi, rubella không?" },
            { "7_BiCumCamLanhHoNhucDauHong14Ngay", "7. Trong 14 ngày gần đây, anh/chị có bị cảm, sốt, đau họng không?" },
            { "8_DungThuocKhangSinhKhangViêmAspirinCorticoide7Ngay", "8. Trong 07 ngày gần đây, anh/chị có dùng thuốc kháng sinh, aspirin, corticoid không?" },
            { "9_CauHoiDanhChoPhuNu", "9. Câu hỏi dành cho phụ nữ:" },
            { "10_AnhChiSanSangHienMauNeuDuDieuKien", "10. Anh/chị có sẵn sàng hiến máu mọi lúc khi cần không?" }
        };

        public DonationSummaryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int appointmentId)
        {
            // Lấy thông tin cuộc hẹn, bao gồm Donor, BloodType, MedicalCenter
            var appointment = _context.DonationAppointments
                .Include(a => a.BloodType)
                .Include(a => a.MedicalCenter)
                .FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null)
                return NotFound();

            // Lấy thông tin Donor (profile)
            var donor = _context.Donor
                .Include(d => d.Account)
                .FirstOrDefault(d => d.DonorID == appointment.DonorID);

            // Lấy các câu trả lời khảo sát sức khỏe
            Dictionary<string, string> answers = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(appointment.HealthSurvey))
            {
                answers = JsonConvert.DeserializeObject<Dictionary<string, string>>(appointment.HealthSurvey);
            }
            ViewBag.HealthSurveyAnswers = answers;
            ViewBag.HealthSurveyQuestions = HealthSurveyQuestions;

            // Truyền dữ liệu sang view
            var viewModel = new DonationSummaryViewModel
            {
                Appointment = appointment,
                Donor = donor,
                HealthSurveyAnswers = answers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int appointmentId)
        {
            var appointment = _context.DonationAppointments.FirstOrDefault(a => a.AppointmentID == appointmentId);
            if (appointment != null)
            {
                var surveys = _context.HealthSurveys
                    .Where(h => h.AppointmentID != null && h.AppointmentID == appointmentId)
                    .ToList();
                if (surveys.Any())
                {
                    _context.HealthSurveys.RemoveRange(surveys);
                }

                _context.DonationAppointments.Remove(appointment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}