using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMDB.Models
{
    public class Movie : Entity
    {
        public double? BoxOffice { get; set; }
        
        public double? Budget { get; set; }
        
        public DateTime? Release { get; set; }
               
        public Collection<Genre> Genres { get; set; }
             
        public string Tagline { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public int MovieStudioId { get; set; }
        public int Length { get; set; }

        public string Language { get; set; }

        public string Website { get; set; }

    }
}
