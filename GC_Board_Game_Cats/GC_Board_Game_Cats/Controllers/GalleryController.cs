using Microsoft.AspNetCore.Mvc;

namespace GC_Board_Game_Cats.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
