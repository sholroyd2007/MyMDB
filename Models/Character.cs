namespace MyMDB.Models
{
    public class Character : Entity
    {
        public CastCrewMember CastCrewMember { get; set; }
        public int CastCrewMemberId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }
    }
}
