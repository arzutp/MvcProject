using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        //Metodların mutlaka viewda karşılığı olmalı
        public ActionResult Index()  //listeleme işleri
        {
            return View();
        }

        public ActionResult About()  //Hakkında metodu
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Test()
        {
            return View(); //geriye bir sayfa döndürecek
        }

    }
}