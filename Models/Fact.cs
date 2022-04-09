using System;

namespace MyMDB.Models
{
    public class Fact : Entity
    {
        public FactType FactType { get; set; }
        public int FactTypeId { get; set; }

        public CastCrewMember CastCrewMember { get; set; }
        public int? CastCrewMemberId { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public TVShow TVShow { get; set; }
        public int? TVShowId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }
    }
}
