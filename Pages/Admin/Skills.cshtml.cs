using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    
    public class SkillsModel : PageModel
    {
        AppDbContext db;
        public Skills skill { get; set; }
        public SkillsModel(AppDbContext db)
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
        public IActionResult OnPost(Skills skill)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Skill.Add(skill);
                db.SaveChanges();
                return RedirectToPage("ShowSkills");

            }
            return Page();
            
            


        }
    }
}
