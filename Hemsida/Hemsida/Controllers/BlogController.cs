using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult AddBlogg(string cat, string text)
        {
            using (var db = new HemsidaEntities())
            {
                string userId = User.Identity.GetUserId();
                var repos = new BlogRepos();
                repos.AddBlogg(cat, text, userId);
                return View();
            }
        }
    }
}