using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OOPsReview;
using System.Text.Json;
using System.IO;

namespace WebApp.Pages.Samples
{
    public class ReadJSONModel : PageModel
    {
        // a sample of constructor injection dependency
        private IWebHostEnvironment _env;

        public ReadJSONModel(IWebHostEnvironment env)
        {
            _env=env;
        }

        public string FeedBack { get; set; }

        public string ErrorMsg { get; set; }

        [BindProperty]
        public string fileName { get; set; }

        public Employee employee { get; set; }

        public void OnGet()
        {
        }


        public void OnPostRead()
        {
            //the phyiscal path to the top of your web site
            string contentPathName = _env.ContentRootPath; //the phyiscal path
            string filePathName = Path.Combine(contentPathName, @"Data\" + fileName);
            FeedBack = filePathName;
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IncludeFields = true
                };
                string jsonstring = System.IO.File.ReadAllText(filePathName);
                employee = JsonSerializer.Deserialize<Employee>(jsonstring, options);
                FeedBack = $"Employee id {employee.EmployeeId} has {employee.EmploymentPositions.Count()} positions";
            }
            catch(Exception ex)
            {
                ErrorMsg = ex.Message;
            }
        }
    }
}
