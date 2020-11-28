using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            string charArray = "bajsandes";
            char[] theArray = charArray.ToCharArray();
            int index = 0;
            string bajs = "";
            foreach (char item in theArray)
            {
                if (item % 2 == 0)
                {
                    bajs += item;
                }
                index++;
            }
            ViewBag.Message = bajs;
            return View();
        }
        public ActionResult Fun()
        {
            var array = new ArrayList();
            array.Add(" hej");
            array.Add(" san");
            array.Add(" vad");
            array.Add(" guu");
            array.Add(" duuu");
            string empty = "";
            foreach (string item in array)
            {
                empty += item;
            }
            ViewBag.Message = empty;
            return View();
        }
    }
}