using Iportfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowServicesModel : PageModel
    {
        AppDbContext db;
        public List<Model.Services> services { get; set; }
        public ShowServicesModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            services = db.tbl_Services.ToList();
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
            var itemtodel = db.tbl_Services.Find(id);
            if (itemtodel != null)
            {
                db.tbl_Services.Remove(itemtodel);
                db.SaveChanges();
                return RedirectToPage("ShowServices");
            }
            else
            {
                return RedirectToPage("ShowServices");
            }
        }
    }
}
