using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeContact2
{
    public class Contact
    {
        //Id|FirstName|LastName|Email|Photo
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }


        public Contact()
        {
            Id = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Photo = string.Empty;

        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}"; 
        }
    }
}
