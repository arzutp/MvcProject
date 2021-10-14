using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.WriterPanel
{
    public class WriterContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        // GET: WriterContent
        
        public ActionResult MyContent(string p)
        {              
            p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetLogin(p);
            var value = cm.GetWriterList(writeridinfo);
            return View(value);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content c)
        {
            c.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetLogin(p);
            c.WriterId = writeridinfo;
            c.ContentStatus = true;
            cm.Add(c);
            return RedirectToAction("MyContent");
        }


    }
}