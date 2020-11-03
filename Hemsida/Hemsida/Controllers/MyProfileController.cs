using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using Hemsida.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult OtherUserProfile(string id)
        {
            var profile = new UserInfo(id);
            ViewBag.Profile = profile;
            return View(profile);
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
    }
}
