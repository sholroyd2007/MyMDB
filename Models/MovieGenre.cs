namespace MyMDB.Models
{
    public class GenreLink : Entity
    {
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public int? TVShowId { get; set; }
        public TVShow TVShow { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
