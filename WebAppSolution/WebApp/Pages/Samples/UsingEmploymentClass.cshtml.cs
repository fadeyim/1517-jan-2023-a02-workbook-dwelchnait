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

        public string ErrorMsg { get; set; }

        [BindProperty]
        public Employment employment { get; set; }

        [BindProperty]
        public SupervisoryLevel supervisorylevel { get; set; }

        [BindProperty]
        public DateTime startdate { get; set; }

        public void OnGet()
        {
        }

        public void OnPostAccept()
        {
            try
            {
                employment.CorrectStartDate(startdate);
                FeedBack = employment.ToString();
            }
            catch (ArgumentNullException ex)
            {
                ErrorMsg = ex.Message;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ErrorMsg = ex.Message;
            }
            catch (ArgumentException ex)
            {
                ErrorMsg = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
        }
    }
}
