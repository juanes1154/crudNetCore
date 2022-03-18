using CrudNetCore.Data;
using CrudNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Blog> lstBlogs = _context.Blog;
            return View(lstBlogs);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blog.Add(blog);
                _context.SaveChanges();

                TempData["message"] = "The blog was saved correctly";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }

            var blog = _context.Blog.Find(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blog.Update(blog);
                _context.SaveChanges();

                TempData["message"] = "The blog was updated correctly";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var blog = _context.Blog.Find(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBlog(int? id)
        {
            var blog = _context.Blog.Find(id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blog);
            _context.SaveChanges();

            TempData["message"] = "The blog was deleted correctly";
            
            return RedirectToAction("Index");
        }

    }
}
