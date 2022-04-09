namespace MyMDB.Models
{
    public class Article : Entity
    {
        public CastCrewMember CastCrewMember { get; set; }
        public int CastCrewMemberId { get; set; }

        public Character Character { get; set; }
        public int? CharacterId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public TVShow TVShow { get; set; }
        public int? TVShowId { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int? MovieStudioId { get; set; }

        public MovieSeries MovieSeries { get; set; }
        public int? MovieSeriesId { get; set; }

        public Award Award { get; set; }
        public int? AwardId { get; set; }
    }
}
