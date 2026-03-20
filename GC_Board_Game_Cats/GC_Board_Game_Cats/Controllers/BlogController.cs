using GC_Board_Game_Cats.Data;
using GC_Board_Game_Cats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GC_Board_Game_Cats.Controllers
{
    public class BlogController : Controller
    {
        AppDbContext context;

        public BlogController(AppDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            var blogPosts = context.BlogPosts
                .Include(b => b.AppUser)
                .OrderByDescending(b => b.DatePosted)
                .ToList();
            return View(blogPosts);
        }

        public IActionResult AboutAuthor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Users"] = context.AppUsers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            blogPost.DatePosted = DateTime.Now;
            // Set to admin user if not provided
            if (blogPost.AppUserId == 0)
            {
                blogPost.AppUserId = 1;
            }

            context.BlogPosts.Add(blogPost);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
