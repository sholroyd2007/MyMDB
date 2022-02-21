using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Movie : Entity
    {
        public double? BoxOffice { get; set; }
        
        public double? Budget { get; set; }
        
        public DateTime? Release { get; set; }
        
        public List<CastCrewMember> CastCrewMembers { get; set; }
        
        public List<Genre> Genres { get; set; }
        
        public List<Rating> Ratings { get; set; }
        
        public string Tagline { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int MovieStudioId { get; set; }
        public int Length { get; set; }

        public Movie()
        {
            CastCrewMembers = new List<CastCrewMember>();
            Genres = new List<Genre>();
            Ratings = new List<Rating>();
        }

    }
}
