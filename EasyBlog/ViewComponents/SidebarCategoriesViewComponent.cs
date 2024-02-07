using EasyBlog.Data;
using Microsoft.AspNetCore.Mvc;

namespace EasyBlog.Components
{
    public class SidebarCategoriesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public SidebarCategoriesViewComponent(ApplicationDbContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _db.Categories.ToList(); 
            return View(categories);
        }
    }
}
