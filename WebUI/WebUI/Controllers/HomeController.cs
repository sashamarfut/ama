using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContext a = new DatabaseContext();

            string s = a.AspNetUsers.First(x => x.UserName == "sasha").UserName;

            
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
