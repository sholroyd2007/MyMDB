using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Episode : Entity
    {
        public DateTime AirDate { get; set; }

        public List<CastCrewMember> CastCrewMembers { get; set; }

        public int SeriesNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public TVShow TVShow { get; set; }
        public int TVShowId { get; set; }

        public Episode()
        {
            CastCrewMembers = new List<CastCrewMember>();
        }


    }
}
