using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class ResidentAddress
    {
        //data members
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit; //infers a fully-implemented property
        private string _City; //infers a fully-implemented property
        public string ProvinceState;

        //properties
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        //constructors
        public ResidentAddress(int number, string Address1, string Address2,
                                string unit, string city, string provincestate)
        {
            Number = number;
            //each instance of a class has an internal keyword that points to the
            //  instance in memory when it exists
            //that keyword is -> this.
            //By using the this. on the reference to the variable Address1/2 the code
            //  is being told to use the data member instead of the parameter of the
            //  same name
            this.Address1 = Address1;
            this.Address2 = Address2;
            Unit = unit;
            City = city;
            ProvinceState = provincestate;
        }
        //behaviours
        public override string ToString()
        {
            return $"{Number},{Address1},{Address2},{Unit},{City},{ProvinceState}";
        }
    }
}
