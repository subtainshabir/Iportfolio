using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iportfolio.Model
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Need to be fill.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Occupation is Required")]
        public string Occupation { get; set; }
        [Required(ErrorMessage = "Rewiew is Required")]
        public string Review { get; set; }
        [Required(ErrorMessage = "Image is Required")]
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }

    }
}
