using EasyBlog.Data;
using EasyBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index(int? cid)
        {
            IQueryable<Post> posts = _db.Posts;

            if (cid.HasValue) //cid != null
            {
                posts = posts.Where(posts => posts.CategoryId == cid); // kosula uyan postlari getir
                ViewBag.CategoryName = _db.Categories.Find(cid)?.Name;
            }

            return View(posts.OrderByDescending(p => p.Id).ToList());
        }

        [Route("Post/{id:int}")]
        public IActionResult ShowPost(int id)
        {
            var post = _db.Posts.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
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
