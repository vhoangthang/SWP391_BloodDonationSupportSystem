﻿using System.ComponentModel.DataAnnotations;

namespace BloodDonationSupport.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại người dùng")]
        public string Role { get; set; }

        public bool RememberMe { get; set; }
    }
}
