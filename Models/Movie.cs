using System;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class Movie : Entity
    {
        public double? BoxOffice { get; set; }
        
        public double? Budget { get; set; }
        
        public DateTime? Release { get; set; }
        
        public List<ProductionRole> ProductionRoles { get; set; }
        
        public List<Genre> Genres { get; set; }
        
        public List<Rating> Ratings { get; set; }
        
        public string Tagline { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int MovieStudioId { get; set; }
        public int Length { get; set; }

        public Movie()
        {
            ProductionRoles = new List<ProductionRole>();
            Genres = new List<Genre>();
            Ratings = new List<Rating>();
        }

    }
}
