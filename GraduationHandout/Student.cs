using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationHandout
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }
        public Address Address { get; set; }

        public Student ()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Major = string.Empty;
            GPA = 0;
            Address = new Address(); //or = null;

        }

        public Student(string firstName, string lastName, string major, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            GPA = gpa;
            Address = new Address();

        }

        public string CalculateDistinction()
        {
            string distinction;
            if (GPA >= 3.80)
            {
                distinction = "summa cum laude";
            }
            else if (GPA >= 3.60)
            {
                distinction = "magna cum laude";
            }
            else if (GPA >= 3.40)
            {
                distinction = "cum laude";
            }
            else
            {
                distinction = "No Special Distiction";
            }

            return distinction;
        }

        public void SetAddress(int streetNumber, string streetName, string state, string city, int zipcode)
        {
            Address = new Address(streetNumber, streetName, state, city, zipcode);

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Major}, {CalculateDistinction()}.";
        }

    }
}
