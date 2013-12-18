using ServerProject.Models;
using ServerProject.Models.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ObservableCollection<LineUp> temp =  LineUpRepository.GetLineUps();

            return View(temp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
