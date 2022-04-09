using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMDB.Models
{
    public class TVShow : Entity
    {
        public CastCrewMember Creator { get; set; }

        public int CreatorId { get; set; }

        public Collection<Genre> Genres{ get; set; }

        public bool Active { get; set; }

        public int EpisodeLength { get; set; }

        public string Language { get; set; }

        public string Website { get; set; }

    }
}
