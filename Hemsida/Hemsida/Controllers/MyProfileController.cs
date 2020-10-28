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
        //public ActionResult VisitMyProfile()
        //{
        //    string myId = User.Identity.GetUserId();

        //}
    }
}