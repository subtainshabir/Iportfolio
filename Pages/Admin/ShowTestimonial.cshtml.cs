using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowTestimonialModel : PageModel
    {
        AppDbContext db;
    
        public List<Testimonial> Testimonials { get; set; }
        public ShowTestimonialModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            Testimonials = db.tbl_Testimonial.ToList();
            var flagvalue = HttpContext.Session.GetString("flag");
            if (flagvalue != "true")
            {
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
            
        }
    


    }
}
