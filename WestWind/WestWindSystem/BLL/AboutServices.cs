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
    public class AboutServices
    {
        //this class needs to allow access from software that is outside
        //  of the class library project, therefore, this class will
        //  have an access type of public


        #region setup the context connection variable and class constructor
        //this class will need to have a context connection setup to access
        //   the database
        //this setup is only required within this class library, therefore,
        //  to add a level of security, the access to the constructor will be
        //  internal

        //variable to hold an instance of the context class
        //limit use of this access to within this class
        private readonly WestWindContext _context;

        //constructor to be used in the creation of the instance of this class
        //the registered reference for the context connection will be
        //  passed from the register services
        internal AboutServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        //create a method (service) that will retrieve the BuildVersion Record
        public BuildVersion GetBuildVersion()
        {
            //we need to access the DbSet<T> in the context class that
            //  has been setup to transport the data from the database to
            //  our class library application
            //_context is the instance of the DAL context class
            //BuildVersions is the DbSet<T> property for the sql table
            //<T> represents the entity that maps the contents of the sql table
            //BY DEFAULT, ALL records of the sql table will be return to the DbSet
            //  by default your return a collection of sql table records
            //However, we can restrict the number of records from the database
            //  by using appropriate Linq query commands/methods
            //Use the method FirstOrDefault() to restrict the return collection
            //  to a single record (instance) from the database records
            //  First: get the first record on the table that matches the request condition
            //  Default: if no record is found matching the request condition return a null
            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }
        #endregion
    }
}
