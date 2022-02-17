namespace MyMDB.Models
{
    public class ProductionRole : Entity
    {
        public CastCrewMember CastCrewMember { get; set; }
        public int CastCrewMemberId { get; set; }

        public JobRole JobRole { get; set; }
        public int JobRoleId { get; set; }

        public Character Character { get; set; }
        public int? CharacterId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public bool CreditOnly { get; set; }
    }
}
