using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyBoardUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts = 1)
        {
            ViewBag.Donuts = donuts;
            return View();
        }
        [Authorize]
        public ActionResult Three()
        {
            return View();
        }




    }
}