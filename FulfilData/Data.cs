using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilData
{
    public class Data
    {
        public string State { get; set; }
        public string Gender { get; set; }
        public double Mean { get; set; }
        public int N { get; set; }
    
        public Data()
        {
            State = string.Empty;
            Gender = string.Empty;
            Mean = 0;
            N = 0;
        }


    }
}
