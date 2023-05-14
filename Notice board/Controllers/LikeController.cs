using Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Notice_board.Services;

namespace Notice_board.Controllers
{
    public class LikeController : Controller
    {
        private readonly AdvertDbContext context;
        private readonly ILikeService likeService;

        public LikeController(AdvertDbContext context, ILikeService likeService)
        {
            this.context = context;
            this.likeService = likeService;
        }
        public IActionResult Index()
        {
            return View(likeService.GetAll());
        }

        public IActionResult Add(int id)
        {
            likeService.Add(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            likeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}

