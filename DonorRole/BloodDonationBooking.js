// Tạo lịch động và lưu ngày đã chọn vào localStorage
const days = ["CN", "T2", "T3", "T4", "T5", "T6", "T7"];
const datePicker = document.getElementById("datePicker");
const today = new Date();
const numDaysToShow = 15;

function formatDateLocal(date) {
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const day = String(date.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

for (let i = 0; i < numDaysToShow; i++) {
  const date = new Date(today);
  date.setDate(today.getDate() + i);
  const dayOfWeek = days[date.getDay()];
  const day = date.getDate();

  const div = document.createElement("div");
  div.classList.add("date");

  const thisDateStr = formatDateLocal(date);
  const selectedDate = localStorage.getItem("selectedDate");

  if (thisDateStr === selectedDate) {
    div.classList.add("active");
  }

  div.innerHTML = `${dayOfWeek}<br>${day}`;
  div.addEventListener("click", function () {
    document.querySelectorAll(".date").forEach(el => el.classList.remove("active"));
    div.classList.add("active");

    const selectedDate = formatDateLocal(date);
    localStorage.setItem("selectedDate", selectedDate);
  });

  datePicker.appendChild(div);
}

// Chuyển từ tab 1 qua tab 2
function switchTab(tabId) {
  document.querySelectorAll(".tab").forEach(t => t.classList.remove("active"));
  document.querySelectorAll(".container").forEach(c => c.classList.add("hidden"));
  document.getElementById(tabId).classList.remove("hidden");

  const button = Array.from(document.querySelectorAll(".tab")).find(b =>
    b.textContent.includes(tabId === 'tab1' ? "Thời gian" : "Phiếu")
  );
  if (button) button.classList.add("active");

  // GỌI LẠI HÀM KHI CHUYỂN TAB 2
  if (tabId === 'tab2') {
    renderSummary();
  }
}
// chuyển màu time slot để dễ nhìn
const timeButtons = document.querySelectorAll('.time-slots button');

  timeButtons.forEach(button => {
    button.addEventListener('click', () => {
      timeButtons.forEach(btn => btn.classList.remove('selected')); // bỏ chọn các nút khác
      button.classList.add('selected'); // đánh dấu nút được chọn
    });
  });
// Lưu nhóm máu
const bloodButtons = document.querySelectorAll('.blood-types button');
bloodButtons.forEach(button => {
  button.addEventListener('click', () => {
    bloodButtons.forEach(b => b.classList.remove('selected'));
    button.classList.add('selected');
    localStorage.setItem('selectedBloodType', button.textContent.trim());
  });
});

// Lưu khung giờ
const timeButtons1 = document.querySelectorAll('.time-slots button');
timeButtons1.forEach(button => {
  button.addEventListener('click', () => {
    timeButtons1.forEach(b => b.classList.remove('selected'));
    button.classList.add('selected');
    localStorage.setItem('selectedTime', button.textContent);
  });
});
// chuyển từ Form nhập dữ liệu về lại tab 2
window.addEventListener("DOMContentLoaded", () => {
  const urlParams = new URLSearchParams(window.location.search);
  const tab = urlParams.get("tab");
  if (tab === "tab2") {
    switchTab("tab2");
    renderSummary(); // hàm để hiển thị dữ liệu tóm tắt
  }
});

// Hàm hiển thị thông tin đã lưu trong BloodDobationBooking và BloodDantionForm
function renderSummary(){
  // === Hiển thị dữ liệu Form 1 ===
    const selectedDate = localStorage.getItem('selectedDate') || 'Chưa chọn';
    const selectedTime = localStorage.getItem('selectedTime') || 'Chưa chọn';
    const selectedBloodType = localStorage.getItem('selectedBloodType') || 'Chưa chọn';

    document.getElementById('selectedDate').textContent = selectedDate;
    document.getElementById('selectedTime').textContent = selectedTime;
    document.getElementById('selectedBloodType').textContent = selectedBloodType;

    // === Hiển thị dữ liệu Form 2 ===
    const form2Answers = JSON.parse(localStorage.getItem('form2Answers') || '{}');
    const container = document.getElementById('questionsContainer');
    
    document.getElementById("qrTimeInfo").innerHTML = `Thời gian: <strong>${selectedTime} - ${selectedDate}</strong>`;

    const questions = [
      "1. Anh/chị từng hiến máu chưa?",
      "2. Hiện tại, anh/chị có mắc bệnh lý nào không?",
      "3. Trước đây, anh/chị có từng mắc một trong các bệnh sau không?",
      "4. Trong 12 tháng gần đây, anh/chị có :",
      "5. Trong 06 tháng gần đây, anh/chị có khỏi bệnh sau các bệnh truyền nhiễm, viêm tủy không?",
      "6. Trong 01 tháng gần đây, anh/chị có khỏi bệnh viêm tiết niệu, viêm phổi, rubella không?",
      "7. Trong 14 ngày gần đây, anh/chị có bị cảm, sốt, đau họng không",
      "8. Trong 07 ngày gần đây, anh/chị có dùng thuốc kháng sinh, aspirin, corticoid không?",
      "9. Câu hỏi dành cho phụ nữ:",
      "10. Anh/chị có sẵn sàng hiến máu mọi lúc khi cần không?"
    ];

    let index = 1;
    for (const [key, value] of Object.entries(form2Answers)) {
      const p = document.createElement('p');
      const formattedValue = Array.isArray(value) ? value.join(', ') : value;
      p.innerHTML = `<span class="label">${questions[index - 1]} <br></span> ${formattedValue || 'Không trả lời'}`;
      container.appendChild(p);
      index++;
    }
}
function clearAllData() {
  localStorage.clear();
  window.location.href = "Homepage.html";
}