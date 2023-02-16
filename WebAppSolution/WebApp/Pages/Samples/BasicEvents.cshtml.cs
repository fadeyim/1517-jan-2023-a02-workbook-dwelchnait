using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        public string Feedback { get; set; }
        private Random random = new Random();


        public void OnGet()
        {
            //executes when the page is "first" time the page is created
            // OR
            //if your form has a method set to get
            Feedback = "Welcome to the page";
        }

        //the default post method for these pages is called OnPost
        //if your form has a method set to post AND no
        //  pagehandler is specified on the submit button
        //  the default even is OnPost.
        public void OnPost()
        {
            int oddeven = random.Next(1, 101);
            if (oddeven % 2 == 0)
            {
                Feedback = $"Your value {oddeven} is even.";
            }
            else
            {
                Feedback = $"Your value {oddeven} is odd.";
            }
        }

        //this event will execute in response to a button on the
        //  form that has asp-page-handler parameter set to the
        //  appended name on OnPost
        public void OnPostSecondButton()
        {
            Feedback = "You have directed this request to a specific OnPost event.";
        }
    }
}
