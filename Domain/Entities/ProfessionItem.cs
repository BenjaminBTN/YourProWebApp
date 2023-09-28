using System.ComponentModel.DataAnnotations;

namespace YourProfessionWebApp.Domain.Entities {
    public class ProfessionItem {

        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Заполните название профессии")]
        [Display(Name = "Название профессии")]
        public string Title { get; set; }

        [Display(Name = "Полное описание профессии")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Заполните сопутствующие интересы")]
        [Display(Name = "Сопутствующие интересы")]
        public List<Interest> Interests { get; set; }

    }
}
