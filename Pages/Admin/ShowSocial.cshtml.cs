using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowSocialModel : PageModel
    {
        AppDbContext db;
        public List<SocialNetworks> social { get; set; }
        public ShowSocialModel(AppDbContext db)
        {
            this.db=db;
        }
        public IActionResult OnGet()
        {
            social = db.tbl_SocialNetwork.ToList();
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
            var itemtodel = db.tbl_SocialNetwork.Find(id);
            if (itemtodel != null)
            {
                db.tbl_SocialNetwork.Remove(itemtodel);
                db.SaveChanges();
                return RedirectToPage("ShowSocial");
            }
            return Page();
        }
    }
}
