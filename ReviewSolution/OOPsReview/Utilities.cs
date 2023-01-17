using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        //static classes are NOT instantiated by the outside user (developer/code)
        //static class items are referenced using the classname.xxxxx
        //methods with in this class have the keyword static in their signature
        //static classes are shared between all outside users at the same time
        //DO NOT consider saving data within a static class BECAUSE you cannot be
        //  certain it will be there when you use the class again
        //consider placing GENERIC re-usable methods within a static class

        //sample of a generic method: numeric is a zero positive value
        public static bool IsZeroPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(double value)
        {
            bool valid = true;
            if (value < 0.0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(decimal value)
        {
            bool valid = true;
            if (value < 0.0m)
            {
                valid = false;
            }
            return valid;
        }
    }
}
