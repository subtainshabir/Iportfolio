using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.Admin
{
    public class loginModel : PageModel
    {
        AppDbContext db;
        public User user { get; set; }
        public loginModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(User user) 
        { 
            if (ModelState.IsValid)
            {
                var result=db.tbl_user.Where(opt=> opt.username.Equals(user.username) && opt.password.Equals(user.password)).FirstOrDefault();
                if (result !=null)
                {
                    HttpContext.Session.SetString("flag", "true");
                    return RedirectToPage("Index");
                    
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }

    }
}
