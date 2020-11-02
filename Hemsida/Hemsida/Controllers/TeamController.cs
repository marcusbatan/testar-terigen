using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult Index([Bind(Exclude = "teamLogo")] Team team)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["teamLogo"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                team.teamLogo = imageData;
                using (var db = new HemsidaEntities())
                {
                    var repos = new TeamRepos();
                    var addTeam = repos.addTeam(team.teamName, team.teamLogo);
                    ViewBag.mess = "Du har nu reggat ett lag!";
                }
            }
            return View(team);
        }
    }
}