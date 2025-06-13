document.getElementById('donationForm').addEventListener('submit', function (e) {
  e.preventDefault();

  const formData = {};
  const form = e.target;

  // Lặp từng nhóm câu hỏi
  const questions = form.querySelectorAll('.question');
  questions.forEach((q, index) => {
    const inputs = q.querySelectorAll('input');
    const name = inputs[0]?.name;
    if (!name) return;

    // Nếu là radio (chỉ 1 lựa chọn)
    if (inputs[0].type === 'radio') {
      const selected = q.querySelector(`input[name="${name}"]:checked`);
      formData[name] = selected ? selected.value : '';
    }

    // Nếu là checkbox (nhiều lựa chọn)
    else if (inputs[0].type === 'checkbox') {
      const selectedOptions = Array.from(inputs)
        .filter(input => input.checked)
        .map(input => input.value);
      formData[name] = selectedOptions;
    }
  });

  // Lưu vào localStorage
  localStorage.setItem('form2Answers', JSON.stringify(formData));

  // Chuyển sang trang tóm tắt
  window.location.href = 'BloodDonationBooking.html?tab=tab2'; 
  //BloodDonationBooking.html?tab=tab2
  //BookingConfirm(Recycle)/BookingConfirm.html
});
