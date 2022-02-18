namespace MyMDB.Models
{
    public class Quote : Entity
    {
        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Character Character { get; set; }
        public int? CharacterId { get; set; }
    }
}
