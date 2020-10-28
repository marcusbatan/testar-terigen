using Hemsida.Data.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class MyProfileController : Controller
    {
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
    }
}