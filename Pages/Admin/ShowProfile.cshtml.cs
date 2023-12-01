using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowProfileModel : PageModel
    {
        public Profile profile { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public ShowProfileModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db= db;
            this.env = env;
        }
        public IActionResult OnGet()
        {
            profile = db.tbl_Profile.FirstOrDefault();
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

        public IActionResult OnPost(Profile profile)
        {
            if (profile.Photo != null)
            {
                string ImageName= profile.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "Images");
                var ImagePath=Path.Combine(FolderPath, ImageName);
                
                FileStream fs=new FileStream(ImagePath, FileMode.Create);
                profile.Photo.CopyTo(fs);

                profile.Image = ImageName;
                db.tbl_Profile.Update(profile);
                db.SaveChanges();
                


            }
            else
            {
                //string OldImage = profile.Image;
                //profile.Image = OldImage;
                db.tbl_Profile.Update(profile);
                db.SaveChanges();

            }
            return RedirectToPage("ShowProfile");

        }
    }
}
