using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowSkillsModel : PageModel
    {
        AppDbContext db;
        public List<Skills> skills { get; set; }
        public ShowSkillsModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            skills = db.tbl_Skill.ToList();
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
            var itemtodel = db.tbl_Skill.Find(id);
            if (itemtodel != null)
            {
                db.tbl_Skill.Remove(itemtodel);
                db.SaveChanges();
                return RedirectToPage("ShowSkills");
            }
            return RedirectToPage("ShowSkills");
        }
    }
}
