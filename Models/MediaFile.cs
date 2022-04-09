using System.Collections.ObjectModel;

namespace MyMDB.Models
{
    public class MediaFile : Entity
    {
        public byte[] Data { get; set; }

        public string ContentType { get; set; }

        public Collection<CastCrewMember> CastCrewMembers { get; set; }
        public Collection<Character> Characters { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public TVShow TVShow { get; set; }
        public int? TVShowId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Award Award { get; set; }
        public int? AwardId { get; set; }

        public Genre Genre { get; set; }
        public int? GenreId { get; set; }

        public MovieSeries MovieSeries { get; set; }
        public int? MovieSeriesId { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int? MovieStudioId { get; set; }

    }
}
