using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddBlogg()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBlogg(Blog blog)
        {
            using (var db = new HemsidaEntities())
            {
                string userId = User.Identity.GetUserId();
                var repos = new BlogRepos();
                repos.AddBlogg(blog.Category, blog.Text, userId);
                return View(blog);
            }
        }
        public ActionResult SeeMyBlogs()
        {
            using (var db = new HemsidaEntities())
            {
                var userId = User.Identity.GetUserId();
                var blogPost = db.Blog.Where(b => b.UserId == userId).ToList().OrderByDescending(b => b.BlogId);
                return View(blogPost);
            }
        }
    }
}