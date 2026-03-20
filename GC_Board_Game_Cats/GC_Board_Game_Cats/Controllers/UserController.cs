using GC_Board_Game_Cats.Data;
using GC_Board_Game_Cats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GC_Board_Game_Cats.Controllers
{
    public class UserController : Controller
    {
        AppDbContext context;

        public UserController(AppDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            var users = context.AppUsers.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                context.AppUsers.Add(appUser);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appUser);
        }
    }
}
