using Microsoft.AspNetCore.Mvc;
using Notice_board.Data;
using Notice_board.Entities;
using System.Diagnostics;

namespace Notice_board.Controllers
{
    public class AdvertsController : Controller
    {

        //static List<Advert> adverts = new List<Advert>()
        //{
        //new Advert(){Id=1, Name="MacBook 2019", CategoryId=1, Price=1500, City="Rovno",Description="Normal view",ContactInformation="0974585652"},
        //new Advert(){Id=2, Name="Iphone 13", CategoryId=1,Price=850, City="Luchk",Description="Cool view",ContactInformation="0634584521"},
        //new Advert(){Id=3, Name="MacBook 2021", CategoryId=1,Price=2200, City="Lviv",Description="New",ContactInformation="0665241245"}
        //};

        private AdvertDbContext context;

        public AdvertsController() 
        {
            context = new AdvertDbContext();
        }

        //GET: ~/adverts/index
        [HttpGet]      //defoult
        
        public IActionResult Index()
        {
            var adverts= context.Adverts.ToList();
            //get adverts from database
            return View(adverts);
        }
        public IActionResult DeleteAdvert(int id)
        {
             var item = context.Adverts.Find(id);
            if (item == null)
                return NotFound();
            
            context.Adverts.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DitailsAdvert(int id) 
        {
            var item = context.Adverts.Find(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

    }

    //class AdvertViewModel
    //{
    //    public int Collection1 { get; set; }
    //    public int Collection2 { get; set; }
    //}
}
