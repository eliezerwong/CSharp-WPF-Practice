using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeJsonSerialization
{
    public class Games
    {
        //name,platform,release_date,summary,meta_score,user_review
        public string name { get; set; }
        public string platform { get; set; }
        public string release_date { get; set; }
        public string summary { get; set; }
        public string meta_score { get; set; }
        public string user_review { get; set; }

        public Games()
        {
            name = string.Empty;
            platform = string.Empty;
            release_date = string.Empty;
            summary = string.Empty;
            meta_score = string.Empty;
            user_review = string.Empty;
        }

        public override string ToString()
        {
            return $"{name} - {platform}"; 
        }
    }
}
