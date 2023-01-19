using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        //data members
        private string _Title;
        private double _Years;
        //properties

        //Title cannot be empty
        //since there is validation, the property will be fully-implemented
        //since fully-implemented, one requires a data member
        public string Title
        {
            //referred to as the accessor
            //get is a required item in a property
            get { return _Title; }
            //referred to as the mutator
            //incoming data is accessed using the keyword value
            //the set is an optional item in a property
            //open to the public by default
            //can be restricted to use ONLY with the property
            //  by setting the access to the set to: private
            //IF the set is private the only way to access a value
            //  to the property is via: a constructor OR a behaviour
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                else
                {
                    _Title = value;
                }
            }
        }
        //enum SupervisoryLevel will not have any additional logic
        //therefore this property can be auto-implemented
        //the private set will NOT allow a piece of code outside of this class
        //  to change the value of the property
        //this will force any code using this class to set the Level either by
        //  the a constructor OR a behaviour
        //it basically makes the Level a read only field when accessed directly
        public SupervisoryLevel Level { get; private set; }

        //Year will need to be a positive zero or greater value
        //int
        //therefore this property needs to be fully-implemented IF
        //  the validation is within the property
        //NOTE: validations CAN be code elsewhere within your class
        //      if so, you need to restrict the set access to the
        //      property so that any data will be forced through the
        //      validation logic located elsewhere
        public double Years
        {
            get { return _Years; }
            set
            {
                //this validation test is using a method from the static class Utilities
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentOutOfRangeException("Year must be a number 0.0 or greater.");

                }
                else
                {
                    _Years = value;
                }
            }
        }
        //constructors
        public Employment()
        {
            //default constructor
            //simulates the "system default constructor"
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            //optionally one could set years to zero, but that is
            //  the system default for a double, therefore one does
            //  not need to assign a value UNLESS you wish to
        }

        public Employment(string title, SupervisoryLevel level, double year = 0.0)
        {
            Title=title;
            Level=level;
            Years=year;
        }


        //behaviours
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //the property has a private set
            //therefore this behaviour allows outside code to give the property a value
            Level = level;
        }

        public override string ToString()
        {
            //this string is known as a "comma separate value" string (csv)
            //the get of the property is being used
            return $"{Title},{Level},{Years}";
        }
    }
}
