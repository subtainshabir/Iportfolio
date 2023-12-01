using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowFactsModel : PageModel
    {
        AppDbContext db;
        public List<Facts> facts { get; set; }
        public ShowFactsModel(AppDbContext db)
        {
            this.db= db;
            
        }
        public IActionResult OnGet()
        {
            facts=db.tbl_Facts.ToList();
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
        public IActionResult OnPostDelete(int id)
        {
            var itemtodel = db.tbl_Facts.Find(id);
            if (itemtodel != null)
            {
                db.tbl_Facts.Remove(itemtodel);
                db.SaveChanges();
                return RedirectToPage("ShowFacts");
            }
            return RedirectToPage("ShowFacts");
        }
    }
}
