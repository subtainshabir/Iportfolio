using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class UpdateEducationModel : PageModel
    {
        AppDbContext db;
        public Education education { get; set; }
        public UpdateEducationModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_Education.Find(id);
            education = itemtoupdate;
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
        public IActionResult OnPost(Education education)
        {
            db.tbl_Education.Update(education);
            db.SaveChanges();
            return RedirectToPage("ShowEducation");

        }
    }
}
