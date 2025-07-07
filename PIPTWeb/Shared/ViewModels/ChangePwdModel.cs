using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.ViewModels
{
    public class ChangePwdModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu cũ")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu mới")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập lại mật khẩu mới")]
        [Compare(nameof(NewPassword), ErrorMessage = "Mật khẩu không khớp nhau!")]
        public string NewPasswordConfirm { get; set; }
    }
}
