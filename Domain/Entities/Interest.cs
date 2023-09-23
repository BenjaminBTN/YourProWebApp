using System.ComponentModel.DataAnnotations;

namespace YourProfessionWebApp.Domain.Entities {
    public class Interest : BaseEntity {

        [Required]
        [Display(Name = "Название увлечения")]
        public override string Title { get; set; }
    }
}
