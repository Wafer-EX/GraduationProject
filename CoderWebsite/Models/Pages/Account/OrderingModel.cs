using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Account
{
    public class OrderingModel
    {
        [Required(ErrorMessage = "Поле ФИО должно быть заполнено.")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле название заказа должно быть заполнено.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле номер телефона должно быть заполнено.")]
        [Phone(ErrorMessage = "Данные в поле номер телефона не являются номером телефона.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле электронная почта должно быть заполнено.")]
        [EmailAddress(ErrorMessage = "Данные в поле электронная почта не являются электронной почтой.")]
        public string Email { get; set; }
    }
}