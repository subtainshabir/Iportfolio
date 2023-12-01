using System.ComponentModel.DataAnnotations;

namespace Iportfolio.Model
{
    public class Education
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Degree Title is Required")]
        public string DegreeTitle { get; set; }
        [Required(ErrorMessage = "Start Year is Required")]
        public string StartClass { get; set; }
        [Required(ErrorMessage = "End Year is Required")]
        public string EndClass { get; set; }

        [Required(ErrorMessage = "Institute Name is Required")]
        public string InstituteName { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        
    }
}
