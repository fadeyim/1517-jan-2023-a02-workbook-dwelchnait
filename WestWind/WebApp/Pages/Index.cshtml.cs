using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespace
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //
        // create a variable to hang onto the injected service identifier
        private readonly AboutServices _aboutServices;

        //Constructor
        //this constructor receives an injection of a service
        //this injection is referred to as a Constructor Injection Dependency
        //the injections is setup just like any other parameter   type paramname
        //ILogger is a service that was here by default
        //we wish in inject the services of AboutServices into this web page

        public IndexModel(ILogger<IndexModel> logger,
                            AboutServices aboutservices)
        {
            _logger = logger;
            _aboutServices = aboutservices;
        }

        public BuildVersion dbVersion { get; set; }
        public void OnGet()
        {
            //make use of the query service in the class library under AboutServices
            //get data from the database via the class lirary AboutServices method GetBuildVersion()
            dbVersion = _aboutServices.GetBuildVersion();
        }
    }
}