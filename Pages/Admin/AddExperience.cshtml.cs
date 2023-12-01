using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class AddExperienceModel : PageModel
    {
        AppDbContext db;
        public Experience experience { get; set; }
        public AddExperienceModel(AppDbContext db)
        {
            this.db= db;
            
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
        public IActionResult OnPost(Experience experience)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Experience.Add(experience);
                db.SaveChanges();
                return RedirectToPage("ShowExperience");

            }
            return Page();
            
        }
    }
}
