using Microsoft.AspNetCore.Mvc;
using MyMDB.Data;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
