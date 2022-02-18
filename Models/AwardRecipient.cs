namespace MyMDB.Models
{
    public class AwardRecipient : Entity
    {
        public Award Award { get; set; }
        public int AwardId { get; set; }

        public AwardCategory AwardCategory { get; set; }
        public int AwardCategoryId { get; set; }

        public int Year { get; set; }

        public bool Win { get; set; }

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
