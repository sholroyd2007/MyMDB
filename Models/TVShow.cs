using System.Collections;
using System.Collections.Generic;

namespace MyMDB.Models
{
    public class TVShow : Entity
    {
        public CastCrewMember Creator { get; set; }
        public int CreatorId { get; set; }

        public List<Episode> Episodes { get; set; }

        public List<Genre> Genres{ get; set; }

        public bool Active { get; set; }

        public int EpisodeLength { get; set; }

        public TVShow()
        {
            Episodes = new List<Episode>();
            Genres = new List<Genre>();
        }
    }
}
