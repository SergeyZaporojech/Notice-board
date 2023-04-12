using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        private readonly AdvertDbContext context;
        public AdvertsController(AdvertDbContext context)
        {
            this.context = context;
        }

        private void LoadCategories()
        {
            // ViewData dictionary colleciton
            //ViewData["CategoryList"] = ...

            // ViewBag - dynamic property collection
            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), "Id", "Name");
            //ViewBag.Username = "vladtymo";
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

        public IActionResult CreateAdvert()
        {
            LoadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult CreateAdvert(Advert advert)
        {

            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View("CreateAdvert");
            }
           context.Adverts.Add(advert);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditAdvert(int id)
        {
            var advert = context.Adverts.Find(id);
            if (advert == null)
                return NotFound();  
            LoadCategories();
            return View(advert);
        }

        [HttpPost]
        public IActionResult EditAdvert(Advert advert)
        {

            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View("EditAdvert");
            }
            context.Adverts.Update(advert);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }

    //class AdvertViewModel
    //{
    //    public int Collection1 { get; set; }
    //    public int Collection2 { get; set; }
    //}
}
