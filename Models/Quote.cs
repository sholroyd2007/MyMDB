namespace MyMDB.Models
{
    public class Quote : Entity
    {
        public int? MovieId { get; set; }
        public int? EpisodeId { get; set; }
        public int? CharacterId { get; set; }
    }
}
