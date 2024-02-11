using System.ComponentModel.DataAnnotations;

namespace YourProWebApp.Domain.Entities {
    public class ProfessionItem {

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните название профессии")]
        [Display(Name = "Название профессии")]
        public string Title { get; set; }

        [Display(Name = "Полное описание профессии")]
        public string Text { get; set; }

        [Display(Name = "Категория или отрасль")]
        public string Category { get; set; }

        [Display(Name = "Сопутствующие интересы")]
        public List<int> InterestsId { get; set; }

    }
}
