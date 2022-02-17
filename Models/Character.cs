namespace MyMDB.Models
{
    public class Character : Entity
    {
        public int ActorId { get; set; }
        public CastCrewMember Actor { get; set; }

        public int? MovieId { get; set; }
        public int? EpisodeId { get; set; }
    }
}
