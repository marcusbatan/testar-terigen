using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
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
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                var time = DateTime.Now;
                string userId = User.Identity.GetUserId();
                var repos = new BlogRepos();
                blog.Img = imageData;
                repos.AddBlogg(blog.Category, blog.Text, userId, time, blog.Img);
                return View(blog);
            }
        }
        public ActionResult BlogSide(Guid id)
        {
            using (var db = new HemsidaEntities())
            {
                var blog = new Blog(id);
                ViewBag.Blog = blog;
                return View(blog);
            }
        }
        public ActionResult SeeMyBlogs()
        {
            using (var db = new HemsidaEntities())
            {
                var userId = User.Identity.GetUserId();
                var blogPost = db.Blog.Where(b => b.UserId == userId).ToList().OrderByDescending(b => b.DateTime);
                return View(blogPost);
            }
        }
        public ActionResult SeeAllBlogs()
        {
            using (var db = new HemsidaEntities())
            {
                var blogs = db.Blog.ToList().OrderByDescending(u => u.DateTime);
                return View(blogs);
            }
        }
        public ActionResult GetCategory(string cat)
        {
            using (var db = new HemsidaEntities())
            {
                var getBlogsByCat = db.Blog.Where(u => u.Category == cat).ToList().OrderByDescending(u => u.DateTime);
                return View(getBlogsByCat);
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
                var getBlog = db.Blog.Where(u => u.BlogId == id).FirstOrDefault();
                if (getBlog.Img != null)
                {
                    return new FileContentResult(getBlog.Img, "image/jpeg");
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