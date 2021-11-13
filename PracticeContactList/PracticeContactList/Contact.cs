using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeContactList
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Contact()
        {
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
