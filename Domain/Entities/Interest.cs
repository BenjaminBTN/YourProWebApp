using System.ComponentModel.DataAnnotations;

namespace YourProfessionWebApp.Domain.Entities {
    public class Interest {

        [Required] 
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название увлечения")]
        public string Title { get; set; }
    }
}
