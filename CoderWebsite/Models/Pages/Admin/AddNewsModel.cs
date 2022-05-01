using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Admin
{
    public class AddNewsModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
