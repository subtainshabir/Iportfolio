using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class AddEducationModel : PageModel
    {
        AppDbContext db;
        public Education education { get; set; }
        public AddEducationModel(AppDbContext db)
        {
            this.db = db;
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
        public IActionResult OnPost(Education education)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Education.Add(education);
                db.SaveChanges();
                return RedirectToPage("ShowEducation");

            }
            return Page();


        }
    }
}
