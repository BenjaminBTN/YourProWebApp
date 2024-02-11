using System.ComponentModel.DataAnnotations;

namespace YourProWebApp.Domain.Entities {
    public class TextField {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public string Text { get; set; } = "Содержание заполняется администратором";
    }
}
