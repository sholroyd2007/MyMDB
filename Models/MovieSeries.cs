﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMDB.Models
{
    public class MovieSeries : Entity
    {
        public Collection<Movie> Movies { get; set; }
    }
}
