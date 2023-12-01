using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages
{
    public class IndexModel : PageModel
    {
        AppDbContext db;
        public Profile? profile { get; set; }
        public Contact contact { get; set; }
        public Facts facts { get; set; }
        public List<Skills> skills { get; set; }
        public List<Education> education { get; set; }
        public List<Experience> experiences { get; set; }
        public SocialNetworks social { get; set; }
        public List<Services> service { get; set; }
        public List<Testimonial> testimonials { get; set; }
        public IndexModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            
            profile = db.tbl_Profile.FirstOrDefault();
            facts = db.tbl_Facts.FirstOrDefault();
            skills = db.tbl_Skill.ToList();
            education=db.tbl_Education.ToList();
            experiences=db.tbl_Experience.ToList();
            social = db.tbl_SocialNetwork.FirstOrDefault();
            service = db.tbl_Services.ToList();
            testimonials = db.tbl_Testimonial.ToList();
            
        }
        public IActionResult OnPost(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Contact.Add(contact);
                db.SaveChanges();
                return RedirectToPage("index");
            }
            else
            {
                profile = db.tbl_Profile.FirstOrDefault();
                facts = db.tbl_Facts.FirstOrDefault();
                skills = db.tbl_Skill.ToList();
                education = db.tbl_Education.ToList();
                experiences = db.tbl_Experience.ToList();
                social = db.tbl_SocialNetwork.FirstOrDefault();
                service = db.tbl_Services.ToList();
                testimonials = db.tbl_Testimonial.ToList();
                
                return Page();
            }

        }
    }
}
