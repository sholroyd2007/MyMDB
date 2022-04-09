using System.Collections.ObjectModel;

namespace MyMDB.Models
{
    public class ListArticle: Entity
    {
        public Collection<Movie> Movies { get; set; }

        public Collection<CastCrewMember> CastCrewMembers { get; set; }

        public Collection<TVShow> TVShows { get; set; }

        public Collection<Episode> Episodes { get; set; }

        public Collection<Character> Characters { get; set; }

        public Collection<Award> Awards { get; set; }

        public Collection<MovieSeries> MovieSeries { get; set; }

        public Collection<MovieStudio> MovieStudios { get; set; }
    }
}
