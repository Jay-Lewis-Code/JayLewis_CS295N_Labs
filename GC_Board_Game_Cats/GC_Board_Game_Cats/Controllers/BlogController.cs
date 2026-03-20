using GC_Board_Game_Cats.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GC_Board_Game_Cats.Controllers
{
    public class BlogController : Controller
    {
        // In-memory storage for blog posts
        private static List<BlogPost> blogPosts = new List<BlogPost>();

        // Mock users
        private static List<AppUser> appUsers = new List<AppUser>
        {
            new AppUser { Id = 1, Username = "admin", Email = "admin@example.com" },
            new AppUser { Id = 2, Username = "contributor", Email = "contributor@example.com" }
        };

        public IActionResult Index()
        {
            // Pass blog posts to view
            return View(blogPosts);
        }

        public IActionResult AboutAuthor()
        {
            // About the author page
            return View();
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            ViewData["Users"] = appUsers;
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            // Set ID
            blogPost.Id = blogPosts.Count + 1;

            // Set the date posted to current date/time
            blogPost.DatePosted = DateTime.Now;

            // Set the AppUser to admin
            blogPost.AppUser = appUsers[0];

            // Add to blog posts list
            blogPosts.Add(blogPost);

            // Echo back the submitted post with success message
            ViewData["SuccessMessage"] = "Blog post created successfully!";
            ViewData["SubmittedPost"] = blogPost;
            ViewData["Users"] = appUsers;

            return View("Create", blogPost);
        }

    }
}
