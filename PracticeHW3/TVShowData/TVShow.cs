using System;
using System.Collections.Generic;
using System.Text;

namespace TVShowData
{
    public class TVShow
    {
        public string Actors { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string RuntimeInMinutes { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Writer { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string TotalSeasons { get; set; }

        public TVShow()
        {
            Actors = string.Empty;
            Awards = string.Empty;
            Country = string.Empty;
            Director = string.Empty;
            Genre = string.Empty;
            Language = string.Empty;
            Plot = string.Empty;
            Poster = string.Empty;
            Rated = string.Empty;
            Released = string.Empty;
            RuntimeInMinutes = string.Empty;
            Title = string.Empty;
            Type = string.Empty;
            Writer = string.Empty;
            Year = string.Empty;
            ImdbID = string.Empty;
            ImdbRating = string.Empty;
            ImdbVotes = string.Empty;
            TotalSeasons = string.Empty;
        }

        public override string ToString()
        {
            return $"{Title} ({Year}), Rated: {Rated}, {Country} in {Language}."; 
        }

    }
}
