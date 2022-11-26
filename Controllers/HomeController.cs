using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyMDB.ViewModels;
using MyMDB.Services;
using MyMDd;
using System.Web;
using MyMDB.Helpers;

namespace MyMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IMyMDBService MyMDBService { get; }
        public IArticleService ArticleService { get; }
        public IMovieService MovieService { get; }
        public ITVService TVService { get; }
        public ISlugService SlugService { get; }

        public HomeController(ILogger<HomeController> logger,
            IMyMDBService myMDBService,
            IArticleService articleService,
            IMovieService movieService,
            ITVService tVService,
            ISlugService slugService)
        {
            _logger = logger;
            MyMDBService = myMDBService;
            ArticleService = articleService;
            MovieService = movieService;
            TVService = tVService;
            SlugService = slugService;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel()
            {
                Birthdays = await MyMDBService.GetHomepageBirthdays(),
                Articles = await ArticleService.GetHomepageArticles(),
                ListArticles = await ArticleService.GetHomepageListArticles(),
                RecommendedMovies = await MovieService.GetHomepageRecommendedMovies(),
                ComingSoonMovies = await MovieService.GetHomepageComingSoonMovies(),
                RecommendedTv = await TVService.GetHomepageRecommendedTv(),
                ComingSoonTv = await TVService.GetHomepageComingSoonTv()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Movie(string id)
        {
            Movie movie;
            int movieId;
            var inputIsId = int.TryParse(id, out movieId);

            if (!inputIsId)
            {
                if (id.ContainsCharactersThatNeedEncoding())
                {
                    id = HttpUtility.UrlEncode(id);
                    id = SlugHelper.Slugify(id);
                }


                movieId = await SlugService.GetEntityIdBySlug<Movie>(id);
            }


            movie = await MovieService.GetMovieById(movieId);
            return View(movie);
        }
    }
}
