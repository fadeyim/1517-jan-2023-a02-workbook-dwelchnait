using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class ReadJSONModel : PageModel
    {
        public string FeedBack { get; set; }

        public string ErrorMsg { get; set; }

        [BindProperty]
        public string fileName { get; set; }

        public void OnGet()
        {
        }


        public void OnPostRead()
        {
            FeedBack = Path.GetFullPath(fileName);
        }
    }
}
