using Microsoft.AspNetCore.Mvc;
using Notice_board.Models;
using System.Diagnostics;

namespace Notice_board.Controllers
{
    public class AdvertsController : Controller
    {

        List<Advert> adverts = new List<Advert>()
        {
        new Advert(){Id=1, Name="MacBook 2019", Category="Leptop", City="Rovno",Description="Normal view",ContactInformation="0974585652"},
        new Advert(){Id=2, Name="Iphone 13", Category="Smartphone", City="Luchk",Description="Cool view",ContactInformation="06345684521"},
        new Advert(){Id=3, Name="MacBook 2021", Category="Leptop", City="Lviv",Description="New",ContactInformation="0665241245"}
        };
        //private readonly ILogger<AdvertsController> _logger;
        public AdvertsController() 
        {
        }

        //GET: ~/adverts/index
        [HttpGet]      //defoult

        
        public IActionResult Index()
        {
            //get adverts from database
            return View(adverts);
        }
    }

    //class AdvertViewModel
    //{
    //    public int Collection1 { get; set; }
    //    public int Collection2 { get; set; }
    //}
}
