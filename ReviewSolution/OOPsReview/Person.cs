namespace OOPsReview
{
    public class Person 
    {
        //example of a composite class
        //a composite class uses other classes/structs in its definition
        //a composite class is recongized with the phrase "has a" class
        //this class of Person "has a" resident address
        //this class has a List<T> where <T> represents a datatype and in this
        //  class<T> is a collection of Employment instances

        //each instance of this class will represent an individual
        //this class will define the following characterists
        //  firstname, lastname, current resident address, list of employment positions

        //private/public data members
        private string _FirstName;
        private string _LastName;

        //public properties
        //properties can either be fully-implemented or auto-implemented

        //properties are associated with a single piece of data
        //properties DO NOT have parameters
        //referencing the income data to a properties is done via the 
        //  keyword value

        //fully implemented property
        //why? (when?)
        //  If you are doing validation against the incoming data before
        //      acceptance, this can be done in the property
        //  if there is additional processing to do against the incoming
        //      data before it is accepted

        public string FirstName
        {
            get { return _FirstName; }
            set 
            {
                //ensure that the incoming data has a phyiscal component
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First Name is required");
                }
                _FirstName = value;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                //ensure that the incoming data has a phyiscal component
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name is required");
                }
                _LastName = value;
            }
        }

        //auto-implemented property
        //holds the given data assuming it is complete valid
        //does not employ the use of a data member
        //the computer system creates the internal storage for the data
        //      and uses an internal name to access the data
        //data held by an auto implemented property CAN ONLY be accessed
        //      using the property
        //public ResidentAddress Address { get; set; }

        public List<Employment> EmploymentPositions { get; set; }

        //properties can be readonly
        //a common usage is taking current instance data and re-purposing
        //  the data into new information
        public string FullName { get { return FirstName + " " + LastName; } }
        public int NumberOfEmployments { get { return EmploymentPositions.Count; } }
        
        //constructor(s)
        //generally you may find "two" version of constructors within a class
        //  definition: "Default" and "Greedy" constructors

        //Default
        // mimics the action that would happen if the class has no coded 
        //      constructor, that is the system default setting of the
        //      private data members/auto implement properties
        // one can assign their own default values
        public Person()
        {
            //the concern in this class is that FirstName and LastName
            //      cannot be empty
            //the default for a string is null
            FirstName = "Unknown";
            LastName = "Unknown";

            //to ensure that any property or logic that uses internal instances
            //  has a physical instance to reference
            //to avoid a unexpected error, ensure a physical instance exists
            EmploymentPositions = new List<Employment>();
        }

        //Greedy
        //brings in a value for each of the data member/auto implement property
        //order is not necessarily important; C# allows for keyword parameters
        //normally, the expect order of incoming argument values will be in
        //  the order of the parameters on the receiving constructor(and/or method)
        public Person(string firstname, string lastname, ResidentAddress address,
                        List<Employment> employmentpositions)
        {
            FirstName=firstname;
            LastName=lastname;
            Address=address;
            EmploymentPositions = employmentpositions;
        }


        //behaviours (a.k.a methods)

        //behaviours are actions against the current data within the exists 
        //  instance

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException("You must supply an employment record for it to be add to this person");
            }
            EmploymentPositions.Add(employment);
        }
    }
}