using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeEx1
{
    public class GME
    {
        // 1        2           3       4           5       6
        //date,open_price,high_price,low_price,close_price,volume
        public string Date { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string ClosePrice { get; set; }
        public string Volume { get; set; }

        public GME()
        {
            Date = string.Empty;
            OpenPrice = string.Empty;
            HighPrice = string.Empty;
            LowPrice = string.Empty;
            ClosePrice = string.Empty;
            Volume = string.Empty;
        }

        public override string ToString()
        {
            return $"{Date}, Min: {LowPrice}"; 
        }
    }
}
