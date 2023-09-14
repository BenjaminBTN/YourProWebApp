using System.ComponentModel.DataAnnotations;

namespace YourProfessionWebApp.Domain.Entities {
    public abstract class BaseEntity {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Карткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Содержание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO metatag Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO metatag Descriprion")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO metateg Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public virtual DateTime CreatedDate { get; set; }

        protected BaseEntity() => CreatedDate = DateTime.UtcNow;
    }
}
