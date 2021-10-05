using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        // GET: About
        public ActionResult Index()
        {

            var aboutValue = am.GetList();
            return View(aboutValue);
        }

        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutAdd(About about)
        {
            am.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult AboutDelete(int id)
        {
            var aboutStatus = am.GetById(id);

            if (aboutStatus.Status == true)
            {
                aboutStatus.Status = false;
            }
            else
            {
                aboutStatus.Status = true;
            }

            am.Delete(aboutStatus);
            return RedirectToAction("Index");
        }
    }
}