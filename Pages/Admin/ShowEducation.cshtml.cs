using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class ShowEducationModel : PageModel
    {
        AppDbContext db;
        public List<Education> education { get; set; }
        public ShowEducationModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            education = db.tbl_Education.ToList();
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
        public void OnGetDelete(int id) 
        {
            var itemtodel = db.tbl_Education.Find(id);
            if (itemtodel != null)
            {
                db.tbl_Education.Remove(itemtodel);
                db.SaveChanges();
                //return RedirectToPage("ShowEducation");
            }
        }
     
        
    }
}
