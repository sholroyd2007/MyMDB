namespace MyMDB.Models
{
    public class Rating : Entity
    {
        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        public Episode Episode { get; set; }
        public int? EpisodeId { get; set; }

        public string Country { get; set; }
    }
}
