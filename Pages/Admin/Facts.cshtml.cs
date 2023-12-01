using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class FactsModel : PageModel
    {
        AppDbContext db;
        public Facts facts { get; set; }
        public FactsModel(AppDbContext db)
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
        public void OnPost(Facts facts)
        {
            db.tbl_Facts.Add(facts);
            db.SaveChanges();
        }
    }
}
