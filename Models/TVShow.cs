using System.Collections;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class TVShow : Entity
    {
        public string Creator { get; set; }

        public IEnumerable<Episode> Episodes { get; set; }

        public IEnumerable<Genre> Genres{ get; set; }

        public bool Active { get; set; }

        public int EpisodeLength { get; set; }
    }
}
