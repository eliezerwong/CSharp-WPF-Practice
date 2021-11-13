using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeClasses2
{
    public class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        private string Aisle;

        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = 0;
            Image = string.Empty;
            Aisle = string.Empty;

        }

        public string GetAisle()
        {
            string aisle = Manufacturer.Substring(0, 1).ToUpper() + Price.ToString().Trim('.', ',', '$');
            return aisle;
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Name}"; 
        }
    }
}
