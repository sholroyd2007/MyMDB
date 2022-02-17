using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Movie : Entity
    {
        public double BoxOffice { get; set; }
        public double Budget { get; set; }
        public DateTime Release { get; set; }
        public IEnumerable<CastCrewMember> CastCrewMembers { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Rating Rating { get; set; }
        public int? RatingId { get; set; }
        public string Tagline { get; set; }
        public int MovieStudioId { get; set; }
        public MovieStudio MovieStudio { get; set; }

    }
}
