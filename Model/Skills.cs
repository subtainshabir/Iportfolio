using System.ComponentModel.DataAnnotations;

namespace Iportfolio.Model
{
    public class Skills
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Skill Name is Required. e.g Python (Programming Language)")]
        public string SkillName { get; set; }
        [Required(ErrorMessage ="Please enter the number between 0 to 100. ")]
        [Range(1,100, ErrorMessage ="Please Enter the number between 1 to 100.")]
        public int Percentage { get; set; }
    }
}
