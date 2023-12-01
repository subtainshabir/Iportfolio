using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public List<Contact> contact { get; set; }
        AppDbContext db;
        public IndexModel(AppDbContext db)
        {
            this.db = db;  
        }
        public IActionResult OnGet()
        {
            contact = db.tbl_Contact.ToList();
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
    }
}
