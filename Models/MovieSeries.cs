using System.Collections.Generic;

namespace MyMDB.Models
{
    public class MovieSeries : Entity
    {
        public List<Movie> Movies { get; set; }

        public MovieSeries()
        {
            Movies = new List<Movie>();
        }
    }
}
