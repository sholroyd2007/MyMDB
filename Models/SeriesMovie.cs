namespace MyMDB.Models
{
    public class SeriesMovie : Entity
    {
        public int SeriesId { get; set; }
        public MovieSeries Series { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
