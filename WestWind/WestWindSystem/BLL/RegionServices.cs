using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        #region setup the context connection variable and class constructor
        private readonly WestWindContext _context;
        internal RegionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        //first query will be used to retreive all the records of the
        //      entity so they may be used in a select control on the
        //      web page
        //this should ONLY be considered IF the entity has very few records
        //this can be considered IF you need the data as part of your
        //      foreign key display handling on your web page
        public List<Region> Regions_GetAll()
        {
            IEnumerable<Region> info = _context.Regions;
            return info.OrderBy(x => x.RegionDescription).ToList();
        }

        //this query will receive a parameter value and return a Region
        //      instance (record) OR a null value (not found)
        public Region Regions_GetByID(int regionid)
        {
            Region info = null;
            //use a query to find a particular record (instance) on the
            //      Regions DbSet (which represents the Regions sql table)
            //Find the first occurance and return
            //If NOT found, return a value of NULL
            info = _context.Regions.FirstOrDefault(anyregionrow => anyregionrow.RegionID == regionid);

            // this is just another version of asking for the same data
            //      from the database
            //info = _context.Regions
            //            .Where(anyregionrow => anyregionrow.RegionID == regionid)
            //            .FirstOrDefault();

            return info;
        }
        #endregion
    }
}
