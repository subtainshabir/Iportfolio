using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class AddProfileModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Profile profile { get; set; }

        public AddProfileModel(AppDbContext db, IWebHostEnvironment _env)
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
        public void OnPost(Profile profile)
        {
            string ImageName = profile.Photo.FileName;
            var foldername = Path.Combine(env.WebRootPath, "Images");
            var ImagePath = Path.Combine(foldername, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            profile.Photo.CopyTo(fs);
            fs.Dispose();

            profile.Image = ImageName;
            db.tbl_Profile.Add(profile);
            db.SaveChanges();

        }
    }
}
