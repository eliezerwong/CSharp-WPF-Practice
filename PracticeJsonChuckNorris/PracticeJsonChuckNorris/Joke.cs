using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeJsonChuckNorris
{
    public class Joke
    {
        //     "categories":[]
        //"created_at":"2020-01-05 13:42:21.795084",
        //"icon_url":"https://assets.chucknorris.host/img/avatar/chuck-norris.png",
        //"id":"OWBACGXbTguTB73iN_fyqw",
        //"updated_at":"2020-01-05 13:42:21.795084",
        //"url":"https://api.chucknorris.io/jokes/OWBACGXbTguTB73iN_fyqw",
        //"value":"The reason why TV shows get interrupted with emergency broadcasts is because Chuck Norris is interrupting the show."

        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }

    }
}
