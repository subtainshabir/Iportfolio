using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class UpdateServiceModel : PageModel
    {
        AppDbContext db;
        public Services service { get; set; }
        public UpdateServiceModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_Services.Find(id);
            service = itemtoupdate;
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
        public IActionResult OnPost(Services service)
        {
            db.tbl_Services.Update(service);
            db.SaveChanges();
            return RedirectToPage("ShowServices");
        }
    }
        
}


