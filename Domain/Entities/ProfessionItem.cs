using System.ComponentModel.DataAnnotations;

namespace YourProfessionWebApp.Domain.Entities {
    public class ProfessionItem : BaseEntity {

        [Required(ErrorMessage = "Заполните название профессии")]
        [Display(Name = "Название профессии")]
        public override string Title { get; set; }

        [Display(Name = "Карткое описание профессии")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание профессии")]
        public override string Text { get; set; }
    }
}
