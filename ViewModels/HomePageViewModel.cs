using MyMDB.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMDB.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<CastCrewMember> Birthdays { get; set; }
         
        public IEnumerable<Article> Articles { get; set; }
         
        public IEnumerable<ListArticle> ListArticles { get; set; }
         
        public IEnumerable<Movie> RecommendedMovies { get; set; } 

        public IEnumerable<TVShow> RecommendedTv { get; set; } 
         
        public IEnumerable<Movie> ComingSoonMovies { get; set; }

        public IEnumerable<Episode> ComingSoonTv { get; set; }
    }
}
