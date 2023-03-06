using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//adding the namespace of the external class for use by this class in
//  this namespace
using OOPsReview;

namespace WebApp.Pages.Samples
{
    public class UsingEmploymentClassModel : PageModel
    {
        public string FeedBack { get; set; }

        [BindProperty]
        public Employment employment { get; set; }

        [BindProperty]
        public SupervisoryLevel supervisorylevel { get; set; }

        [BindProperty]
        public DateTime startdate { get; set; }

        public void OnGet()
        {
        }
    }
}
