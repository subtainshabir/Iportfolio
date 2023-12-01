using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class AddServicesModel : PageModel
    {
        AppDbContext db;
        public Services service { get; set; }
        public AddServicesModel(AppDbContext db)
        {
            this.db=db;
            
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
        public IActionResult OnPost(Model.Services service )
        {
            db.tbl_Services.Add(service);
            db.SaveChanges();
            return RedirectToPage("ShowServices");

        }
    }
}
