using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class Update_ExperienceModel : PageModel
    {
        AppDbContext db;
        public Experience experience { get; set; }
        public Update_ExperienceModel(AppDbContext db)
        {
            this.db=db;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_Experience.Find(id);
            experience = itemtoupdate;
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
        public IActionResult OnPost()
        {
            db.tbl_Experience.Update(experience);
            db.SaveChanges();
            return RedirectToPage("ShowExperience");
        }
    }
}
