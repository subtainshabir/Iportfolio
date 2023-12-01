using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class AddTestimonialModel : PageModel
    {
        public Testimonial testimonial { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;

        public AddTestimonialModel(AppDbContext db, IWebHostEnvironment _env)
        {
            this.db = db;
            this.env = _env;

        }
        public IActionResult OnGet()
        {
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
        public void OnPost(Testimonial testimonial)
        {
            string ImageName = testimonial.Photo.FileName;
            var foldername = Path.Combine(env.WebRootPath, "testimonial_images");
            var ImagePath = Path.Combine(foldername, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            testimonial.Photo.CopyTo(fs);
            fs.Dispose();

            testimonial.Image = ImageName;
            db.tbl_Testimonial.Add(testimonial);
            db.SaveChanges();
        }
    }
}
