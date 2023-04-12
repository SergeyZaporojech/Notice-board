using Data;
using Microsoft.AspNetCore.Mvc;
using Notice_board.Models;
using System.Diagnostics;

namespace Notice_board.Controllers
{
    public class HomeController : Controller
    {

        private readonly AdvertDbContext context;
        public HomeController(AdvertDbContext context)
        {
            this.context = context;
        }
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var adverts = context.Adverts.ToList();
            return View(adverts);
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



    }
}