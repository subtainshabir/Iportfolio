using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class UpdateTestimonialModel : PageModel
    {
        public Testimonial testimonials { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public UpdateTestimonialModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db=db;
            this.env=env;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_Testimonial.Find(id);
            testimonials = itemtoupdate;
            
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
        public IActionResult OnPost(Testimonial testimonials)
        {
            if (testimonials.Photo != null)
            {
                string ImageName = testimonials.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "testimonial_images");
                var ImagePath = Path.Combine(FolderPath, ImageName);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                testimonials.Photo.CopyTo(fs);

                testimonials.Image = ImageName;
                db.tbl_Testimonial.Update(testimonials);
                db.SaveChanges();



            }
            else
            {
              
                db.tbl_Testimonial.Update(testimonials);
                db.SaveChanges();

            }
            return RedirectToPage("ShowTestimonial");

        }
    }
}
