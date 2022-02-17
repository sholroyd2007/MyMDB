namespace MyMDB.Models
{
    public class MediaFile : Entity
    {
        public byte[] Data { get; set; }

        public string ContentType { get; set; }

        public int? MovieId { get; set; }
        public int? CastCrewMemberId { get; set; }
        public int? TVShowId { get; set; }
        public int? EpisodeId { get; set; }
        public int? AwardId { get; set; }
        public int? GenreId { get; set; }
        public int? MovieSeriesId { get; set; }
        public int? MovieStudioId { get; set; }
    }
}
