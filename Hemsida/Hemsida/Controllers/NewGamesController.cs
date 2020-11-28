using Hemsida.Data.DAL;
using Hemsida.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class NewGamesController : Controller
    {
        // GET: NewGames
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new HemsidaEntities())
            {
                string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
                SqlConnection _con = new SqlConnection(constr);
                SqlDataAdapter _da = new SqlDataAdapter("Select * From Teams", constr);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);
                ViewBag.CityList = ToSelectList(_dt, "CityID", "CityName");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Games games)
        {
            using (var db = new HemsidaEntities())
            {
                var repos = new NewGameRepos();
                repos.AddGames(games);
                return View(games);
            }
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}  
