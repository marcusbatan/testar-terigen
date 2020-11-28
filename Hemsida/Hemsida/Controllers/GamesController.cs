using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? homeScore, int? awayScore, Guid homeTeam, Guid awayTeam)
        {
            using (var db = new HemsidaEntities())
            {
                var listOfTeams = db.Teams.toList();
                if(listOfTeams != null)
                {
                    Viewbag.Data = listOfTeams;
                }
                var repos = new GameRepos();
                var addGame = repos.AddGames(homeScore, awayScore, homeTeam, awayTeam);
                return View();
            }
        }
    }
}