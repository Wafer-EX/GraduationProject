using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле адреса электронной почты должно быть заполнено.")]
        [EmailAddress(ErrorMessage = "Поле адреса электронной почты должно содержать адрес электронной почты.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле пароля должно быть заполнено.")]
        [DataType(DataType.Password, ErrorMessage = "Введенный текст не является паролем.")]
        [MinLength(8, ErrorMessage = "Длина пароля должна быть не менее 8 символов.")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}