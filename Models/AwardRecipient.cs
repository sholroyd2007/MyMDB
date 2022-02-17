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

        public int? CastCrewMemberId { get; set; }
        public int? EpisodeId { get; set; }
        public int? TVShowId { get; set; }
        public int? MovieId { get; set; }
    }
}
