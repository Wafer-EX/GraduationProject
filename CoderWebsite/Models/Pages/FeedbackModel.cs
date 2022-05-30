using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Электронная почта является обязательной.")]
        [EmailAddress(ErrorMessage = "Введенное значение не является адресом электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Сообщение должно содержать текст.")]
        public string Message { get; set; }
    }
}