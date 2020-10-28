using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class ListUsersController : Controller
    {
        // GET: ListUsers
        public ActionResult Index(string search)
        {
            using (var db = new HemsidaEntities())
            {
                var repos = new AppUserRepos();
                var listOfUsers = repos.ListUsers(search);
                return View(listOfUsers);
            }
        }
    }
}