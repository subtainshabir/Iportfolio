using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class SocialNetworksModel : PageModel
    {
        AppDbContext db;
        public SocialNetworks social { get; set; }
        public SocialNetworksModel(AppDbContext db)
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
        public void OnPost(SocialNetworks social)
        {
            db.tbl_SocialNetwork.Add(social);
            db.SaveChanges();

        }
    }
}
