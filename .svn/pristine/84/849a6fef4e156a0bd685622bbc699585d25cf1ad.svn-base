using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.ViewModels
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Yêu cầu phải nhập tài khoản!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Yêu cầu phải nhập mật khẩu!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
