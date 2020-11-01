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
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string teamName, byte[] teamLogo)
        {
            if (ModelState.IsValid)
            {
                byte[] logo = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase imgFile = Request.Files["teamLogo"];
                    using (var binary = new BinaryReader(imgFile.InputStream))
                    {
                        logo = binary.ReadBytes(imgFile.ContentLength);
                    }
                }
            }
            using (var db = new HemsidaEntities())
            {
                var repos = new TeamRepos();
                var addTeam = repos.addTeam(teamName, teamLogo);
                ViewBag.mess = "Du har nu reggat ett lag!";
                return View(addTeam);
            }
        }
    }
}