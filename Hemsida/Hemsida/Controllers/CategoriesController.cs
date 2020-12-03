using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCat(Category cat)
        {
            using(var db = new HemsidaEntities())
            {
                var repos = new CategoryRepos();
                var createCat = repos.CreateCategory(cat.CategoryName, cat.Description);
                return View(cat);
            }
        }
    }
}