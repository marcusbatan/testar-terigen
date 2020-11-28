using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using Hemsida.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class MyProfileController : Controller
    {
        private HemsidaEntities db = new HemsidaEntities();
        // GET: MyProfile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisitMyProfile()
        {
            string myId = User.Identity.GetUserId();
            var profile = new UserInfo(myId);
            ViewBag.Profile = profile;
            ViewBag.Id = myId;
            return View(profile);
        }
        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();

                if (userId == null)
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
                var getUserinfo = db.UserInfo.Where(u => u.userId == userId).FirstOrDefault();

                return new FileContentResult(getUserinfo.Img, "image/jpeg");
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

        public ActionResult UpdateValues()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInfo = db.UserInfo.Where(u => u.userId == id).FirstOrDefault();
            var theId = userInfo.id;
            UserInfo info = db.UserInfo.Find(theId);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var repos = new AppUserRepos();
                repos.UpdateValuesOnUser(userInfo);
            }
            return View(userInfo);
        }
        public ActionResult GetUsersWithInterests()
        {
            try
            {
                var db = new HemsidaEntities();
                List<UserInfo> listOfUsers = db.UserInfo.ToList();
                var loggedInUser = User.Identity.GetUserId();
                var getUser = db.UserInfo.Where(u => u.userId == loggedInUser).FirstOrDefault();
                var loggedInUserName = getUser.userName;
                UserInfo info = new UserInfo();
                var query = from u in db.UserInfo
                            where u.userName.Equals(loggedInUser)
                            where u.userId != getUser.userId
                            select u;
                listOfUsers = query.ToList();
                return View(listOfUsers);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
