using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1
{
    public class CarSales
    {
        // 0    1    2     3    4       5
        //vin,make,color,year,model,sale_price

        public string vin { get; set; }
        public string make { get; set; }
        public string color { get; set; }
        public int year { get; set; }
        public string model { get; set; }
        public string sale_price { get; set; }

        public CarSales()
        {
            vin = string.Empty;
            make = string.Empty;
            color = string.Empty;
            year = 0;
            model = string.Empty;
            sale_price = string.Empty;
        }

        public override string ToString()
        {
            return $"{year} {make} - {model}"; 
        }


    }
}
