using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class UpdateSocialModel : PageModel
    {
        AppDbContext db;
        public SocialNetworks social { get; set; }
        public UpdateSocialModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_SocialNetwork.Find(id);
            social = itemtoupdate;
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
        public IActionResult OnPost(SocialNetworks social)
        {
            db.tbl_SocialNetwork.Update(social);
            db.SaveChanges();
            return RedirectToPage("ShowSocial");
        }
    }
}
