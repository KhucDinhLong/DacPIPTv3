using System.ComponentModel.DataAnnotations;

namespace PIPT.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bạn chưa nhập tên đăng nhập!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}