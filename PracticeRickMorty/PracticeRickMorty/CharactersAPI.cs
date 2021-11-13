using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeRickMorty
{
    public class CharactersAPI
    {
        public Info info { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string image { get; set; }

        public override string ToString()
        {
            return name; 
        }
    }

    public class Info
    {
        public string count { get; set; }
        public string pages { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
    }
}
