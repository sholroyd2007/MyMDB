using System.Collections.Generic;

namespace MyMDB.Models
{
    public class MovieSeries : Entity
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
