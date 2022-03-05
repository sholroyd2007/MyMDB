using Microsoft.AspNetCore.Mvc;
using MyMDB.Data;

namespace MyMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemController : Controller
    {
        public SystemController(ApplicationDbContext context)
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
