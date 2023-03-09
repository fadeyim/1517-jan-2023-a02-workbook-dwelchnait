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
        private SupervisoryLevel _Level;
      
        //properties
        public string Title
        {
             get { return _Title; }
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
         public SupervisoryLevel Level 
        { 
            get { return _Level; } 
            set
            {
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory level is invalid: {value}");
                }
                _Level = value;
            }
        }

         public double Years
        {
            get { return _Years; }
            set
            {
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

         public DateTime StartDate { get; set; }

        //constructors
        public Employment()
        {
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;

        }

        public Employment(string title, SupervisoryLevel level, 
                            DateTime startdate,double year = 0.0)
        {
            Title=title;
            Level=level;
            Years=year;
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date is in the future thus invalid:" +
                    $"{startdate}");
            }
            StartDate = startdate;
        }

        //behaviours
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }

        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }

        public void CorrectStartDate(DateTime startdate)
        {
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date is in the future thus invalid:" +
                    $"{startdate}");
            }
            StartDate = startdate;
        }

        public static Employment Parse(string text)
        {
           
            string[] pieces = text.Split(',');

            if (pieces.Length != 4)
            {
                throw new FormatException($"String not in expected format.  Missing value {text}");
            }

            return new Employment(
                                    pieces[0],
                                    (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                                    DateTime.Parse(pieces[2]),
                                    double.Parse(pieces[3])
                                );
        }
       
        public static bool TryParse(string text, out Employment result)
        {
            result = null;

            bool flag = false;
            if(!string.IsNullOrWhiteSpace(text))
            {
                result = Parse(text);
                flag = true;

            }
            return flag;
        }
    }
}
