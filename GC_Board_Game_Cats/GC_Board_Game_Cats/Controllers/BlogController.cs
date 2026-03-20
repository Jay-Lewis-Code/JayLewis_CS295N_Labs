using Microsoft.AspNetCore.Mvc;

namespace GC_Board_Game_Cats.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            // Placeholder page for links to top posts
            return View();
        }

        public IActionResult AboutAuthor()
        {
            // About the author page
            return View();
        }

    }
}
