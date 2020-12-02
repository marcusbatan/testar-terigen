using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProduct(Product product)
        {
            using (var db = new HemsidaEntities())
            {
                var repos = new ProductRepos();
                var createProduct = repos.AddProduct(product);
                return View(createProduct);
            }
        }
    }
}