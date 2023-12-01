using System.ComponentModel.DataAnnotations;

namespace Iportfolio.Model
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required e.g. Jhon")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required e.g. example@mail.com")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Subject is Required")]
        public string subject { get; set; }

        public string Message { get; set; }
    }
}
