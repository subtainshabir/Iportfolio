using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class UpdateFactsModel : PageModel
    {
        AppDbContext db;
        public Facts facts { get; set; }
        public UpdateFactsModel(AppDbContext db)
        {
            
            this.db = db;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_Facts.Find(id);
            facts = itemtoupdate;
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
        public IActionResult OnPost(Facts facts)
        {
            db.tbl_Facts.Update(facts);
            db.SaveChanges();
            return RedirectToPage("ShowFacts");

        }
    }
}
