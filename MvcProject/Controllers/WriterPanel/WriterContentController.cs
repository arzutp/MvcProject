using BusinessLayer.Concrete;
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
        // GET: WriterContent
        public ActionResult MyContent()
        {
            var value = cm.GetWriterList();
            return View(value);
        }
    }
}