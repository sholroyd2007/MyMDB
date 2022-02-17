namespace MyMDB.Models
{
    public class Fact
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public FactType Type { get; set; }
        public int? MovieId { get; set; }
        public int? EpisodeId { get; set; }
        public int? TVShowId { get; set; }
        public int? CastCrewMemberId { get; set; }
    }
}
