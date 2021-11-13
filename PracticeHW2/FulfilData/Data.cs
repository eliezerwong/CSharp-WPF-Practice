using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilData
{
    public class Data
    {
        public string State { get; set; }
        public string Gender { get; set; }
        public string Mean { get; set; }
        public string N { get; set; }

        public Data()
        {
            State = string.Empty;
            Gender = string.Empty;
            Mean = string.Empty;
            N = string.Empty;
        }

        public override string ToString()
        {
            return $"{State} - {Gender}, {Mean} {N}";
        }
    }
}
