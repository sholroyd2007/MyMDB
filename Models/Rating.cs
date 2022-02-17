namespace MyMDB.Models
{
    public class Rating : Entity
    {
        public int? MovieId { get; set; }
        public int? EpisodeId { get; set; }
        public string Country { get; set; }
    }
}
