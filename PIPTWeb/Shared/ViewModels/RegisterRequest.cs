using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.ViewModels
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập họ của mình!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên đệm và tên của mình")]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp nhau!")]
        public string PasswordConfirm { get; set; }
    }
}
