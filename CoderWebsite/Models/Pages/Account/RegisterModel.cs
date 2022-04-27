using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле имени должно быть заполнено.")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Поле фамилии должно быть заполнено.")]
        public string? Lastname { get; set; }

        public string? Middlename { get; set; }

        [Required(ErrorMessage = "Поле адреса электронной почты должно быть заполнено.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле пароля должно быть заполнено.")]
        [DataType(DataType.Password, ErrorMessage = "Введенный текст не является паролем.")]
        [MinLength(8, ErrorMessage = "Длина пароля должна быть не менее 8 символов.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Поле повторного ввода пароля должно быть заполнено.")]
        [DataType(DataType.Password, ErrorMessage = "Введенный текст не является паролем.")]
        [MinLength(8, ErrorMessage = "Длина подтверждаемого пароля должна быть не менее 8 символов.")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать.")]
        public string? PasswordConfirmation { get; set; }
    }
}