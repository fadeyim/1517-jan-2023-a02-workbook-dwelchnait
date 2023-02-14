using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string OwnerName { get; set; } = "default";
        public void OnGet()
        {
            // this method is call on your behave when the web page is first
            //    created
            // it is called as the web page is being constructed by the system
            // it CAN be call by other code in the rest of this page mdoel class
            OwnerName = "Don";
        }
    }
}