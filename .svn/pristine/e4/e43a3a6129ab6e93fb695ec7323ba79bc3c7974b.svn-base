using Microsoft.AspNetCore.Identity;
using PIPTWeb.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bắt buộc phải nhập tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public List<IdentityRole> Role { get; set; }
        public List<SysMenu> Menus { get; set; }
    }
    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public CurrentUser curentUser { get; set; }
    }
    public class RegisterResponse
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
    public class AuthClaims
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
