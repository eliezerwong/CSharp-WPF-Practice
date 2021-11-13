using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation_Handout
{
    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        public Address()
        {
            StreetNumber = 0;
            StreetName = string.Empty;
            State = string.Empty;
            City = string.Empty;
            Zipcode = 0;

        }

        public Address(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            StreetNumber = streetnumber;
            StreetName = streetname;
            State = state;
            City = city;
            Zipcode = zipcode;

        }

    }
}
