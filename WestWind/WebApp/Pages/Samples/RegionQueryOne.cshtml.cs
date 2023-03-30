using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {
        #region Constructor Injection Depedency setup
        private readonly RegionServices _regionServices;
        public RegionQueryOneModel(RegionServices regionservices)
        {
            _regionServices = regionservices;
        }
        #endregion

        //control / variable setup

        [BindProperty]
        public int txtRegionId { get; set; } //incoming

        [BindProperty]
        public int ddlRegionId { get; set; } //incoming

        public Region regionRecord { get; set; } //outgoing

        public List<Region> regionList { get; set; } //outgoing

        public string Feedback { get; set; }

        public void OnGet()
        {
            regionList = _regionServices.Regions_GetAll();
        }

        public IActionResult OnPostTextRegionQuery()
        {
            if (txtRegionId <1)
            {
                ModelState.AddModelError(nameof(txtRegionId), "Value for id must be a non-zero positive number");
            }
            if(ModelState.IsValid)
            {
                regionRecord = _regionServices.Regions_GetByID(txtRegionId);
                if (regionRecord == null)
                {
                    Feedback=$"Search value {txtRegionId} does not find a matching region.";
                }
            }
            //since I have a control that requires a collection from the
            //  the data, I MUST refresh the collection on each and every event
            regionList = _regionServices.Regions_GetAll();
            return Page();
        }
        public IActionResult OnPostSelectionRegionQuery()
        {
            if (ddlRegionId < 1)
            {
                ModelState.AddModelError(nameof(ddlRegionId), "You need to make a selection from the list");
            }
            if (ModelState.IsValid)
            {
                regionRecord = _regionServices.Regions_GetByID(ddlRegionId);
                if (regionRecord == null)
                {
                    Feedback=$"Search value {ddlRegionId} does not find a matching region.";
                }
            }
            //since I have a control that requires a collection from the
            //  the data, I MUST refresh the collection on each and every event
            regionList = _regionServices.Regions_GetAll();
            return Page();
        }
    }
}
