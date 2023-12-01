using System.ComponentModel.DataAnnotations;

namespace Iportfolio.Model
{
    public class Experience
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Job Title is Required.")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Start Year is Required.")]
        public string StartYear { get; set; }
        [Required(ErrorMessage = "End Year is Required.")]
        public string EndYear { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        public string Desc { get; set; }
    }
}
