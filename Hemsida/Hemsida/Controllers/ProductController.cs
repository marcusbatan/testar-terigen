using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddProduct()
        {
            using (var db = new HemsidaEntities())
            {
                var category = new Category();
                var prod = new Product();
                prod.CategoriesCollection = db.Category.ToList<Category>();
                return View(prod);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product product)
        {

            using (var db = new HemsidaEntities())
            {

                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                product.Img = imageData;
                var repos = new ProductRepos();
                var createProduct = repos.AddProduct(product.Price, product.LongDescription, product.ShortDescription, product.Img, product.Name, product.CategoryId);
                return View(product);
            }
        }
        public ActionResult SelectProductsByCategory(Guid cat)
        {
            using (var db = new HemsidaEntities())
            {
                var getList = db.Product.Where(u => u.CategoryId == cat).ToList().OrderByDescending(u => u.DateTime);
                return View(getList);
            }
        }
        public ActionResult GetAllProducts()
        {
            using (var db = new HemsidaEntities())
            {
                var getAllProds = db.Product.ToList();
                return View(getAllProds);
            }
        }
        public FileContentResult OtherProfilePhoto(Guid id)
        {
            var db = new HemsidaEntities();
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }

                // to get the user details to load user Image
                var getProduct = db.Product.Where(u => u.ProductId == id).FirstOrDefault();
                if (getProduct.Img != null)
                {
                    return new FileContentResult(getProduct.Img, "image/jpeg");
                }
                else
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");
            }
        }
    }
}
