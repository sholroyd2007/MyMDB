namespace MyMDB.Models
{
    public class Character : Entity
    {
        public int CastCrewMemberId { get; set; }
        public CastCrewMember CastCrewMember { get; set; }

        public int? MovieId { get; set; }
        public int? EpisodeId { get; set; }
    }
}
