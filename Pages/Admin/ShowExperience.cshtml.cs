using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowExperienceModel : PageModel
    {
        AppDbContext db;
        public List<Experience> experience { get; set; }
        public ShowExperienceModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            experience = db.tbl_Experience.ToList();
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
        public IActionResult OnGetDelete(int id)
        {
            var itemtodel = db.tbl_Experience.Find(id);
            if (itemtodel != null)
            {
                db.tbl_Experience.Remove(itemtodel);
                db.SaveChanges();
            }
                return RedirectToPage("ShowExperience");
        }
    }
}
