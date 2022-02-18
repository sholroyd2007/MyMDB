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
        
        public IEnumerable<Rating> Ratings { get; set; }
        
        public string Tagline { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int MovieStudioId { get; set; }

    }
}
